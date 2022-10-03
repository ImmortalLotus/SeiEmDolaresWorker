using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using SeiEmDolares.Infra.RepositoryInterface;
using IronPdf;
using System.Text;

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
                var listaDeProtocolosDoSeiEmDolares = _protocoloNoSeiRepository.BuscarMilProtocolos();
                using var contexto = new SeiContext(_seiString);
                using var context = new SeiEmDolaresContext(_seiEmDolaresString);
                var listaDeProcotolosDoSei = _protocoloRepository.GetListaDeProcotolosDoSei(listaDeProtocolosDoSeiEmDolares);
                var renderer = new ChromePdfRenderer()
                {
                    RenderingOptions = new ChromePdfRenderOptions
                    {
                        MarginBottom = 15,
                        MarginLeft = 4,
                        MarginRight = 4,
                        MarginTop = 15,
                        PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait,
                        PaperSize = IronPdf.Rendering.PdfPaperSize.A4
                    }
                };
                foreach (var item in listaDeProcotolosDoSei)
                {
                    var documento = contexto.ConteudoDoDocumento.Where(x => x.DocumentoId == item).First();
                    StringBuilder mtStr = new StringBuilder(documento.Conteudo);
                    mtStr.Append("<div style=\"margin:400px;\"></div>");
                    var html=mtStr.ToString();
                    var pdf = await renderer.RenderHtmlAsPdfAsync(html);
                    var protocolo = context.ProtocoloEmDolares.Where(x=>x.ProtocoloId==item).FirstOrDefault();
                    if(protocolo is not null)
                    {
                        protocolo.FoiImpresso = 1;
                        context.Update(protocolo);
                        await context.SaveChangesAsync();
                        context.ChangeTracker.Clear();
                    }
                    QtdPaginas qtdPaginas = new(pdf.PageCount,item);
                    await context.AddAsync(qtdPaginas);
                    await context.SaveChangesAsync();
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}