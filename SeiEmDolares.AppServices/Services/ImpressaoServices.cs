using iText.Commons.Actions.Contexts;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Renderer;
using Sei.Domain.Entities;
using SeiEmDolares.AppServices.Interfaces;
using SeiEmDolares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeiEmDolares.AppServices.PdfHelper.ConverterProperties;

namespace SeiEmDolares.AppServices.Services
{
    public class ImpressaoServices : IImpressaoServices
    {
        public StringBuilder AdicionandoHeaderEFooter(ConteudoDoDocumento? documento)
        {
            StringBuilder mtStr = new StringBuilder(documento.Conteudo);
            mtStr.Append("<div style=\"margin:400px;\"></div>");
            return mtStr;
        }

        public int GerarPdf(string html)
        {
            int QuantidadeDePaginas=0;
            PdfWriter writer = new PdfWriter("Documento.html");
            PdfDocument document = new PdfDocument(writer);
            ConverterProperties converter = new PdfHelper.ConverterProperties();
            Document document2o=null;
            var task = Task.Run(()=>
            {
                document2o = HtmlConverter.ConvertToDocument(html, document, converter);
            });
            bool rodouBacana=task.Wait(TimeSpan.FromMinutes(30));
            if (rodouBacana)
            {
                document2o!.SetProperty(135, new MetaInfoContainer(ResolveMetaInfo((PdfHelper.ConverterProperties)converter)));
                QuantidadeDePaginas = document.GetNumberOfPages();
                document2o.Close();
            }
            else
            {
                QuantidadeDePaginas = -1;
            }
            document.Close();
            return QuantidadeDePaginas;
        }


        public IMetaInfo ResolveMetaInfo(PdfHelper.ConverterProperties converterProperties)
        {
            if (converterProperties != null)
            {
                return converterProperties.GetEventMetaInfo();
            }

            return new HtmlMetaInfo();
        }
    }
}
