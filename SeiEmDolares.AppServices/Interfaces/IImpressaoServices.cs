using iText.Commons.Actions.Contexts;
using Sei.Domain.Entities;
using SeiEmDolares.AppServices.PdfHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.AppServices.Interfaces
{
    public interface IImpressaoServices
    {
        StringBuilder AdicionandoHeaderEFooter(ConteudoDoDocumento? documento);
        int GerarPdf(string html);
        IMetaInfo ResolveMetaInfo(ConverterProperties converterProperties);
    }
}
