using iText.Commons.Actions.Contexts;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Renderer;
using Microsoft.EntityFrameworkCore;
using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.AppServices.Interfaces;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using SeiEmDolares.Infra.RepositoryInterface;
using System.Text;
using ConverterProperties = iText.Html2pdf.ConverterProperties;

namespace SeiEmDolares.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProtocoloServices _protocoloServices;
        private readonly IImpressaoServices _impressaoServices;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration,
            IProtocoloServices protocoloServices, IImpressaoServices impressaoServices)
        {
            _logger = logger;
            this._protocoloServices = protocoloServices;
            this._impressaoServices = impressaoServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker rodando agora: {time}", DateTimeOffset.Now);

                /*
                    seu código aqui
                 */
                var listaDeProtocolosDoSeiEmDolares =await _protocoloServices.BuscarListaDeProtocolosNoSeiEmDolares();
                var listaDeProcotolosDoSei = await _protocoloServices.BuscarListaDeProtocolosNoSei(listaDeProtocolosDoSeiEmDolares);
                foreach (var item in listaDeProcotolosDoSei)
                {
                    ConteudoDoDocumento? documento = null;
                    documento = await _protocoloServices.BuscarDocumento(item, documento);
                    if (documento is null || documento.Conteudo is null)
                    {
                        await _protocoloServices.AtualizarDocumentoEmBranco(item);
                        continue;
                    }
                    StringBuilder mtStr = _impressaoServices.AdicionandoHeaderEFooter(documento);
                    int QuantidadeDePaginas;
                    var html = mtStr.ToString();
                    try
                    {
                        QuantidadeDePaginas=_impressaoServices.GerarPdf(html);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation("IOException" + ex.Message, DateTimeOffset.Now);
                        await _protocoloServices.AtualizarDocumentoEmBranco(item);
                        continue;
                    }

                    await _protocoloServices.ConfirmarImpressao(item, QuantidadeDePaginas);
                }
                _logger.LogInformation("Mil documentos com sucesso", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}