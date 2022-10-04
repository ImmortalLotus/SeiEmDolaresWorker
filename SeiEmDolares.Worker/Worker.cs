using iText.Commons.Actions.Contexts;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Renderer;
using Microsoft.EntityFrameworkCore;
using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using SeiEmDolares.Infra.RepositoryInterface;
using SeiEmDolares.Worker.PdfHelper;
using System.Text;
using static SeiEmDolares.Worker.PdfHelper.ConverterProperties;
using ConverterProperties = iText.Html2pdf.ConverterProperties;

namespace SeiEmDolares.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProtocoloNoSeiEmDolaresRepository _protocoloNoSeiRepository;
        private readonly IProtocoloRepository _protocoloRepository;
        private readonly string _seiString;
        private readonly string _seiEmDolaresString;


        public Worker(ILogger<Worker> logger,
            IProtocoloNoSeiEmDolaresRepository protocoloNoSeiRepository,
            IProtocoloRepository protocoloRepository,
            IConfiguration configuration)
        {
            _logger = logger;
            _protocoloNoSeiRepository = protocoloNoSeiRepository;
            this._protocoloRepository = protocoloRepository;
            _seiString = configuration.GetConnectionString("SeiDatabase");
            _seiEmDolaresString = configuration.GetConnectionString("SeiEmDolaresDatabase");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                /*
                    seu código aqui
                 */
                var listaDeProtocolosDoSeiEmDolares = await _protocoloNoSeiRepository.BuscarMilProtocolos();
                var listaDeProcotolosDoSei = await _protocoloRepository.GetListaDeProcotolosDoSeiAsync(listaDeProtocolosDoSeiEmDolares);
                foreach (var item in listaDeProcotolosDoSei)
                {
                    ConteudoDoDocumento? documento = null;
                    using (var contexto = new SeiContext(_seiString)) {
                        documento = await contexto.ConteudoDoDocumento.Where(x => x.DocumentoId == item).FirstOrDefaultAsync();
                    }
                    if (documento is null)
                        continue;
                    StringBuilder mtStr = new StringBuilder(documento.Conteudo);
                    mtStr.Append("<div style=\"margin:400px;\"></div>");
                    int QuantidadeDePaginas;
                    var html = mtStr.ToString();
                    PdfWriter writer = new PdfWriter("banana.html");
                    PdfDocument document = new PdfDocument(writer);
                    ConverterProperties converter = new SeiEmDolares.Worker.PdfHelper.ConverterProperties();
                    Document document2o = HtmlConverter.ConvertToDocument(html, document, converter);
                    document2o.SetProperty(135, new MetaInfoContainer(ResolveMetaInfo((PdfHelper.ConverterProperties)converter)));
                    QuantidadeDePaginas =document.GetNumberOfPages();
                    document.Close();
                    using (var context = new SeiEmDolaresContext(_seiEmDolaresString))
                    {
                        var protocolo = context.ProtocoloEmDolares.Where(x => x.ProtocoloId == item).FirstOrDefault();
                        if (protocolo is not null)
                        {
                            protocolo.FoiImpresso = 1;
                            protocolo.Quantidade = QuantidadeDePaginas;
                            context.Update(protocolo);
                            await context.SaveChangesAsync();
                            context.ChangeTracker.Clear();
                        }
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
        public IMetaInfo ResolveMetaInfo(SeiEmDolares.Worker.PdfHelper.ConverterProperties converterProperties)
        {
            if (converterProperties != null)
            {
                return converterProperties.GetEventMetaInfo();
            }

            return new HtmlMetaInfo();
        }
    }
}