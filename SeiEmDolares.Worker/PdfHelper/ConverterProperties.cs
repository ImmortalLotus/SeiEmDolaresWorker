using iText.Commons.Actions.Contexts;
using iText.Html2pdf;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Css.Apply;
using iText.Layout.Font;
using iText.StyledXmlParser.Css.Media;
using iText.StyledXmlParser.Resolver.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Worker.PdfHelper
{
    //
    // Resumo:
    //     Properties that will be used by the iText.Html2pdf.HtmlConverter.
    public class ConverterProperties : iText.Html2pdf.ConverterProperties
    {
        //
        // Resumo:
        //     Default maximum number of layouts.
        private const int DEFAULT_LIMIT_OF_LAYOUTS = 10;

        //
        // Resumo:
        //     The media device description.
        private MediaDeviceDescription mediaDeviceDescription;

        //
        // Resumo:
        //     The font provider.
        private FontProvider fontProvider;

        //
        // Resumo:
        //     The tag worker factory.
        private ITagWorkerFactory tagWorkerFactory;

        //
        // Resumo:
        //     The CSS applier factory.
        private ICssApplierFactory cssApplierFactory;

        //
        // Resumo:
        //     The outline handler.
        private OutlineHandler outlineHandler;

        //
        // Resumo:
        //     The base URI.
        private string baseUri;

        //
        // Resumo:
        //     The resource retriever.
        private IResourceRetriever resourceRetriever;

        //
        // Resumo:
        //     Indicates whether an AcroForm should be created.
        private bool createAcroForm;

        //
        // Resumo:
        //     Character set used in conversion of input streams
        private string charset;

        //
        // Resumo:
        //     Indicates whether the document should be opened in immediate flush or not
        private bool immediateFlush = true;

        //
        // Resumo:
        //     Maximum number of layouts.
        private int limitOfLayouts = 10;

        //
        // Resumo:
        //     Meta info that will be added to the events thrown by html2Pdf.
        private IMetaInfo metaInfo;

        //
        // Resumo:
        //     Instantiates a new iText.Html2pdf.ConverterProperties instance.
        public ConverterProperties()
        {
        }

        //
        // Resumo:
        //     Instantiates a new iText.Html2pdf.ConverterProperties instance based on another
        //     iText.Html2pdf.ConverterProperties instance (copy constructor).
        //
        // Parâmetros:
        //   other:
        //     the other iText.Html2pdf.ConverterProperties instance
        public ConverterProperties(ConverterProperties other)
        {
            mediaDeviceDescription = other.mediaDeviceDescription;
            fontProvider = other.fontProvider;
            tagWorkerFactory = other.tagWorkerFactory;
            cssApplierFactory = other.cssApplierFactory;
            baseUri = other.baseUri;
            resourceRetriever = other.resourceRetriever;
            createAcroForm = other.createAcroForm;
            outlineHandler = other.outlineHandler;
            charset = other.charset;
            metaInfo = other.metaInfo;
            limitOfLayouts = other.limitOfLayouts;
        }

        //
        // Resumo:
        //     Gets the media device description.
        //
        // Devoluções:
        //     the media device description
        //
        // Comentários:
        //     Gets the media device description.
        //     The properties of the multimedia device are taken into account when creating
        //     the SVG and when processing the properties of the СSS.
        public override MediaDeviceDescription GetMediaDeviceDescription()
        {
            return mediaDeviceDescription;
        }

        //
        // Resumo:
        //     Sets the media device description.
        //
        // Parâmetros:
        //   mediaDeviceDescription:
        //     the media device description
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the media device description.
        //     The properties of the multimedia device are taken into account when creating
        //     the SVG and when processing the properties of the СSS.
        public override ConverterProperties SetMediaDeviceDescription(MediaDeviceDescription mediaDeviceDescription)
        {
            this.mediaDeviceDescription = mediaDeviceDescription;
            return this;
        }

        //
        // Resumo:
        //     Gets the font provider.
        //
        // Devoluções:
        //     the font provider
        //
        // Comentários:
        //     Gets the font provider.
        //     Please note that iText.Layout.Font.FontProvider instances cannot be reused across
        //     several documents and thus as soon as you set this property, this iText.Html2pdf.ConverterProperties
        //     instance becomes only useful for a single HTML conversion.
        public override FontProvider GetFontProvider()
        {
            return fontProvider;
        }

        //
        // Resumo:
        //     Sets the font provider.
        //
        // Parâmetros:
        //   fontProvider:
        //     the font provider
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the font provider.
        //     Please note that iText.Layout.Font.FontProvider instances cannot be reused across
        //     several documents and thus as soon as you set this property, this iText.Html2pdf.ConverterProperties
        //     instance becomes only useful for a single HTML conversion.
        public override ConverterProperties SetFontProvider(FontProvider fontProvider)
        {
            this.fontProvider = fontProvider;
            return this;
        }

        //
        // Resumo:
        //     Gets maximum number of layouts.
        //
        // Devoluções:
        //     layouts limit
        public override int GetLimitOfLayouts()
        {
            return limitOfLayouts;
        }

        //
        // Resumo:
        //     Sets maximum number of layouts.
        //
        // Parâmetros:
        //   limitOfLayouts:
        //     layouts limit
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        public override ConverterProperties SetLimitOfLayouts(int limitOfLayouts)
        {
            this.limitOfLayouts = limitOfLayouts;
            return this;
        }

        //
        // Resumo:
        //     Gets the TagWorkerFactory instance.
        //
        // Devoluções:
        //     the TagWorkerFactory
        //
        // Comentários:
        //     Gets the TagWorkerFactory instance.
        //     The tagWorkerFactory is used to create iText.Html2pdf.Attach.ITagWorker , which
        //     in turn are used to convert the HTML tags to the PDF elements.
        public override ITagWorkerFactory GetTagWorkerFactory()
        {
            return tagWorkerFactory;
        }

        //
        // Resumo:
        //     Sets the TagWorkerFactory.
        //
        // Parâmetros:
        //   tagWorkerFactory:
        //     the TagWorkerFactory
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the TagWorkerFactory.
        //     The tagWorkerFactory is used to create iText.Html2pdf.Attach.ITagWorker , which
        //     in turn are used to convert the HTML tags to the PDF elements.
        public override ConverterProperties SetTagWorkerFactory(ITagWorkerFactory tagWorkerFactory)
        {
            this.tagWorkerFactory = tagWorkerFactory;
            return this;
        }

        //
        // Resumo:
        //     Gets the CSS applier factory.
        //
        // Devoluções:
        //     the CSS applier factory
        //
        // Comentários:
        //     Gets the CSS applier factory.
        //     The cssApplierFactory is used to create iText.Html2pdf.Css.Apply.ICssApplier
        //     , which in turn are used to convert the CSS properties to the PDF properties.
        public override ICssApplierFactory GetCssApplierFactory()
        {
            return cssApplierFactory;
        }

        //
        // Resumo:
        //     Sets the CSS applier factory.
        //
        // Parâmetros:
        //   cssApplierFactory:
        //     the CSS applier factory
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the CSS applier factory.
        //     The cssApplierFactory is used to create iText.Html2pdf.Css.Apply.ICssApplier
        //     , which in turn are used to convert the CSS properties to the PDF properties.
        public override ConverterProperties SetCssApplierFactory(ICssApplierFactory cssApplierFactory)
        {
            this.cssApplierFactory = cssApplierFactory;
            return this;
        }

        //
        // Resumo:
        //     Gets the base URI.
        //
        // Devoluções:
        //     the base URI
        //
        // Comentários:
        //     Gets the base URI.
        //     Base URI is used to resolve other URI.
        public override string GetBaseUri()
        {
            return baseUri;
        }

        //
        // Resumo:
        //     Sets the base URI.
        //
        // Parâmetros:
        //   baseUri:
        //     the base URI
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the base URI.
        //     Base URI is used to resolve other URI.
        public override ConverterProperties SetBaseUri(string baseUri)
        {
            this.baseUri = baseUri;
            return this;
        }

        //
        // Resumo:
        //     Gets the resource retriever.
        //
        // Devoluções:
        //     the resource retriever
        //
        // Comentários:
        //     Gets the resource retriever.
        //     The resourceRetriever is used to retrieve data from resources by URL.
        public override IResourceRetriever GetResourceRetriever()
        {
            return resourceRetriever;
        }

        //
        // Resumo:
        //     Sets the resource retriever.
        //
        // Parâmetros:
        //   resourceRetriever:
        //     the resource retriever
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the resource retriever.
        //     The resourceRetriever is used to retrieve data from resources by URL.
        public override ConverterProperties SetResourceRetriever(IResourceRetriever resourceRetriever)
        {
            this.resourceRetriever = resourceRetriever;
            return this;
        }

        //
        // Resumo:
        //     Check if the createAcroForm flag is set.
        //
        // Devoluções:
        //     the createAcroForm flag
        //
        // Comentários:
        //     Check if the createAcroForm flag is set.
        //     If createAcroForm is set, then when the form is encountered in HTML, AcroForm
        //     will be created, otherwise a visually identical, but not functional element will
        //     be created. Please bare in mind that the created Acroform may visually differ
        //     a bit from the HTML one.
        public override bool IsCreateAcroForm()
        {
            return createAcroForm;
        }

        //
        // Resumo:
        //     Sets the createAcroForm value.
        //
        // Parâmetros:
        //   createAcroForm:
        //     true if an AcroForm needs to be created
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the createAcroForm value.
        //     If createAcroForm is set, then when the form is encountered in HTML, AcroForm
        //     will be created, otherwise a visually identical, but not functional element will
        //     be created. Please bare in mind that the created Acroform may visually differ
        //     a bit from the HTML one.
        public override ConverterProperties SetCreateAcroForm(bool createAcroForm)
        {
            this.createAcroForm = createAcroForm;
            return this;
        }

        //
        // Resumo:
        //     Gets the outline handler.
        //
        // Devoluções:
        //     the outline handler
        //
        // Comentários:
        //     Gets the outline handler.
        //     If outlineHandler is specified, then outlines will be created in the PDF for
        //     HTML tags specified in outlineHandler.
        //     Please note that iText.Html2pdf.Attach.Impl.OutlineHandler is not thread safe,
        //     thus as soon as you have set this property, this iText.Html2pdf.ConverterProperties
        //     instance cannot be used in converting multiple HTMLs simultaneously.
        public override OutlineHandler GetOutlineHandler()
        {
            return outlineHandler;
        }

        //
        // Resumo:
        //     Sets the outline handler.
        //
        // Parâmetros:
        //   outlineHandler:
        //     the outline handler
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the outline handler.
        //     If outlineHandler is specified, then outlines will be created in the PDF for
        //     HTML tags specified in outlineHandler.
        //     Please note that iText.Html2pdf.Attach.Impl.OutlineHandler is not thread safe,
        //     thus as soon as you have set this property, this iText.Html2pdf.ConverterProperties
        //     instance cannot be used in converting multiple HTMLs simultaneously.
        public override ConverterProperties SetOutlineHandler(OutlineHandler outlineHandler)
        {
            this.outlineHandler = outlineHandler;
            return this;
        }

        //
        // Resumo:
        //     Gets the encoding charset.
        //
        // Devoluções:
        //     the charset
        //
        // Comentários:
        //     Gets the encoding charset.
        //     Charset is used to correctly decode an HTML file.
        public override string GetCharset()
        {
            return charset;
        }

        //
        // Resumo:
        //     Sets the encoding charset.
        //
        // Parâmetros:
        //   charset:
        //     the charset
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets the encoding charset.
        //     Charset is used to correctly decode an HTML file.
        public override ConverterProperties SetCharset(string charset)
        {
            this.charset = charset;
            return this;
        }

        //
        // Resumo:
        //     Checks if immediateFlush is set.
        //
        // Devoluções:
        //     true if immediateFlush is set, false if not
        //
        // Comentários:
        //     Checks if immediateFlush is set.
        //     This is used for iText.Html2pdf.HtmlConverter.ConvertToDocument(System.String,iText.Kernel.Pdf.PdfWriter)
        //     methods and will be overwritten to false if a page-counter declaration is present
        //     in the CSS of the HTML being converted. Has no effect when used in conjunction
        //     with iText.Html2pdf.HtmlConverter.ConvertToPdf(System.String,System.IO.Stream)
        //     or iText.Html2pdf.HtmlConverter.ConvertToElements(System.String).
        public override bool IsImmediateFlush()
        {
            return immediateFlush;
        }

        //
        // Resumo:
        //     Set the immediate flush property of the layout document.
        //
        // Parâmetros:
        //   immediateFlush:
        //     the immediate flush value
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Set the immediate flush property of the layout document.
        //     This is used for iText.Html2pdf.HtmlConverter.ConvertToDocument(System.String,iText.Kernel.Pdf.PdfWriter)
        //     methods and will be overwritten to false if a page-counter declaration is present
        //     in the CSS of the HTML being converted. Has no effect when used in conjunction
        //     with iText.Html2pdf.HtmlConverter.ConvertToPdf(System.String,System.IO.Stream)
        //     or iText.Html2pdf.HtmlConverter.ConvertToElements(System.String).
        public override ConverterProperties SetImmediateFlush(bool immediateFlush)
        {
            this.immediateFlush = immediateFlush;
            return this;
        }

        //
        // Resumo:
        //     Gets html meta info.
        //
        // Devoluções:
        //     converter's iText.Commons.Actions.Contexts.IMetaInfo
        //
        // Comentários:
        //     Gets html meta info.
        //     This meta info will be used to determine event origin.
        internal virtual IMetaInfo GetEventMetaInfo()
        {
            if (metaInfo != null)
            {
                return metaInfo;
            }

            return new HtmlMetaInfo();
        }
        public class HtmlMetaInfo : IMetaInfo
        {
        }

        //
        // Resumo:
        //     Sets html meta info.
        //
        // Parâmetros:
        //   metaInfo:
        //     meta info to set
        //
        // Devoluções:
        //     the iText.Html2pdf.ConverterProperties instance
        //
        // Comentários:
        //     Sets html meta info.
        //     This meta info will be used to determine event origin.
        public override ConverterProperties SetEventMetaInfo(IMetaInfo metaInfo)
        {
            this.metaInfo = metaInfo;
            return this;
        }
    }
}
#if false // Log de descompilação
'217' itens no cache
------------------
Resolver: 'netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
AVISO: incompatibilidade de versão. Esperado: '2.0.0.0', Obtido: '2.1.0.0'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\netstandard.dll'
------------------
Resolver: 'itext.styledxmlparser, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.styledxmlparser, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.styledxmlparser.dll'
------------------
Resolver: 'itext.layout, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.layout, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.layout.dll'
------------------
Resolver: 'itext.commons, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.commons, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7.commons\7.2.3\lib\netstandard2.0\itext.commons.dll'
------------------
Resolver: 'itext.kernel, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.kernel, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.kernel.dll'
------------------
Resolver: 'itext.svg, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.svg, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.svg.dll'
------------------
Resolver: 'Microsoft.Extensions.Logging.Abstractions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Foi encontrado um assembly: 'Microsoft.Extensions.Logging.Abstractions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
AVISO: incompatibilidade de versão. Esperado: '5.0.0.0', Obtido: '6.0.0.0'
Carregar de: 'C:\Users\06914269963\.nuget\packages\microsoft.extensions.logging.abstractions\6.0.0\lib\net6.0\Microsoft.Extensions.Logging.Abstractions.dll'
------------------
Resolver: 'itext.io, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.io, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.io.dll'
------------------
Resolver: 'itext.forms, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Foi encontrado um assembly: 'itext.forms, Version=7.2.3.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca'
Carregar de: 'C:\Users\06914269963\.nuget\packages\itext7\7.2.3\lib\netstandard2.0\itext.forms.dll'
------------------
Resolver: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.dll'
------------------
Resolver: 'System.IO.MemoryMappedFiles, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.IO.MemoryMappedFiles, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.MemoryMappedFiles.dll'
------------------
Resolver: 'System.IO.Pipes, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.IO.Pipes, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.Pipes.dll'
------------------
Resolver: 'System.Diagnostics.Process, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.Process, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.Process.dll'
------------------
Resolver: 'System.Security.Cryptography.X509Certificates, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Cryptography.X509Certificates, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Cryptography.X509Certificates.dll'
------------------
Resolver: 'System.Memory, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Memory, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Memory.dll'
------------------
Resolver: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Collections.dll'
------------------
Resolver: 'System.Collections.NonGeneric, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Collections.NonGeneric, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Collections.NonGeneric.dll'
------------------
Resolver: 'System.Collections.Concurrent, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Collections.Concurrent, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Collections.Concurrent.dll'
------------------
Resolver: 'System.ObjectModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.ObjectModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.ObjectModel.dll'
------------------
Resolver: 'System.Collections.Specialized, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Collections.Specialized, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Collections.Specialized.dll'
------------------
Resolver: 'System.ComponentModel.TypeConverter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.ComponentModel.TypeConverter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.ComponentModel.TypeConverter.dll'
------------------
Resolver: 'System.ComponentModel.EventBasedAsync, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.ComponentModel.EventBasedAsync, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.ComponentModel.EventBasedAsync.dll'
------------------
Resolver: 'System.ComponentModel.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.ComponentModel.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.ComponentModel.Primitives.dll'
------------------
Resolver: 'System.ComponentModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.ComponentModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.ComponentModel.dll'
------------------
Resolver: 'Microsoft.Win32.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'Microsoft.Win32.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\Microsoft.Win32.Primitives.dll'
------------------
Resolver: 'System.Console, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Console, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Console.dll'
------------------
Resolver: 'System.Data.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Data.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Data.Common.dll'
------------------
Resolver: 'System.Runtime.InteropServices, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.InteropServices, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.InteropServices.dll'
------------------
Resolver: 'System.Diagnostics.TraceSource, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.TraceSource, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.TraceSource.dll'
------------------
Resolver: 'System.Diagnostics.Contracts, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.Contracts, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.Contracts.dll'
------------------
Resolver: 'System.Diagnostics.TextWriterTraceListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.TextWriterTraceListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.TextWriterTraceListener.dll'
------------------
Resolver: 'System.Diagnostics.FileVersionInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.FileVersionInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.FileVersionInfo.dll'
------------------
Resolver: 'System.Diagnostics.StackTrace, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.StackTrace, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.StackTrace.dll'
------------------
Resolver: 'System.Diagnostics.Tracing, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Diagnostics.Tracing, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Diagnostics.Tracing.dll'
------------------
Resolver: 'System.Drawing.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Drawing.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Drawing.Primitives.dll'
------------------
Resolver: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Linq.Expressions.dll'
------------------
Resolver: 'System.IO.Compression.Brotli, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Foi encontrado um assembly: 'System.IO.Compression.Brotli, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.Compression.Brotli.dll'
------------------
Resolver: 'System.IO.Compression, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Foi encontrado um assembly: 'System.IO.Compression, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.Compression.dll'
------------------
Resolver: 'System.IO.Compression.ZipFile, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Foi encontrado um assembly: 'System.IO.Compression.ZipFile, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.Compression.ZipFile.dll'
------------------
Resolver: 'System.IO.FileSystem.DriveInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.IO.FileSystem.DriveInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.FileSystem.DriveInfo.dll'
------------------
Resolver: 'System.IO.FileSystem.Watcher, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.IO.FileSystem.Watcher, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.FileSystem.Watcher.dll'
------------------
Resolver: 'System.IO.IsolatedStorage, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.IO.IsolatedStorage, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.IO.IsolatedStorage.dll'
------------------
Resolver: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Linq.dll'
------------------
Resolver: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Linq.Queryable.dll'
------------------
Resolver: 'System.Linq.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Linq.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Linq.Parallel.dll'
------------------
Resolver: 'System.Threading.Thread, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Threading.Thread, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Threading.Thread.dll'
------------------
Resolver: 'System.Net.Requests, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Requests, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Requests.dll'
------------------
Resolver: 'System.Net.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Primitives.dll'
------------------
Resolver: 'System.Net.HttpListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Net.HttpListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.HttpListener.dll'
------------------
Resolver: 'System.Net.ServicePoint, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Net.ServicePoint, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.ServicePoint.dll'
------------------
Resolver: 'System.Net.NameResolution, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.NameResolution, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.NameResolution.dll'
------------------
Resolver: 'System.Net.WebClient, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Net.WebClient, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.WebClient.dll'
------------------
Resolver: 'System.Net.Http, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Http, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Http.dll'
------------------
Resolver: 'System.Net.WebHeaderCollection, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.WebHeaderCollection, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.WebHeaderCollection.dll'
------------------
Resolver: 'System.Net.WebProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Net.WebProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.WebProxy.dll'
------------------
Resolver: 'System.Net.Mail, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Net.Mail, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Mail.dll'
------------------
Resolver: 'System.Net.NetworkInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.NetworkInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.NetworkInformation.dll'
------------------
Resolver: 'System.Net.Ping, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Ping, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Ping.dll'
------------------
Resolver: 'System.Net.Security, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Security, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Security.dll'
------------------
Resolver: 'System.Net.Sockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.Sockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.Sockets.dll'
------------------
Resolver: 'System.Net.WebSockets.Client, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.WebSockets.Client, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.WebSockets.Client.dll'
------------------
Resolver: 'System.Net.WebSockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Net.WebSockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Net.WebSockets.dll'
------------------
Resolver: 'System.Runtime.Numerics, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.Numerics, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.Numerics.dll'
------------------
Resolver: 'System.Numerics.Vectors, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Numerics.Vectors, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Numerics.Vectors.dll'
------------------
Resolver: 'System.Reflection.DispatchProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Reflection.DispatchProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Reflection.DispatchProxy.dll'
------------------
Resolver: 'System.Reflection.Emit, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Reflection.Emit, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Reflection.Emit.dll'
------------------
Resolver: 'System.Reflection.Emit.ILGeneration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Reflection.Emit.ILGeneration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Reflection.Emit.ILGeneration.dll'
------------------
Resolver: 'System.Reflection.Emit.Lightweight, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Reflection.Emit.Lightweight, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Reflection.Emit.Lightweight.dll'
------------------
Resolver: 'System.Reflection.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Reflection.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Reflection.Primitives.dll'
------------------
Resolver: 'System.Resources.Writer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Resources.Writer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Resources.Writer.dll'
------------------
Resolver: 'System.Runtime.CompilerServices.VisualC, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.CompilerServices.VisualC, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.CompilerServices.VisualC.dll'
------------------
Resolver: 'System.Runtime.InteropServices.RuntimeInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.InteropServices.RuntimeInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.InteropServices.RuntimeInformation.dll'
------------------
Resolver: 'System.Runtime.Serialization.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.Serialization.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.Serialization.Primitives.dll'
------------------
Resolver: 'System.Runtime.Serialization.Xml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.Serialization.Xml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.Serialization.Xml.dll'
------------------
Resolver: 'System.Runtime.Serialization.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.Serialization.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.Serialization.Json.dll'
------------------
Resolver: 'System.Runtime.Serialization.Formatters, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Runtime.Serialization.Formatters, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Runtime.Serialization.Formatters.dll'
------------------
Resolver: 'System.Security.Claims, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Claims, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Claims.dll'
------------------
Resolver: 'System.Security.Cryptography.Algorithms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Cryptography.Algorithms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Cryptography.Algorithms.dll'
------------------
Resolver: 'System.Security.Cryptography.Csp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Cryptography.Csp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Cryptography.Csp.dll'
------------------
Resolver: 'System.Security.Cryptography.Encoding, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Cryptography.Encoding, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Cryptography.Encoding.dll'
------------------
Resolver: 'System.Security.Cryptography.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Security.Cryptography.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Security.Cryptography.Primitives.dll'
------------------
Resolver: 'System.Text.Encoding.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Text.Encoding.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Text.Encoding.Extensions.dll'
------------------
Resolver: 'System.Text.RegularExpressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Text.RegularExpressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Text.RegularExpressions.dll'
------------------
Resolver: 'System.Threading, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Threading, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Threading.dll'
------------------
Resolver: 'System.Threading.Overlapped, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Threading.Overlapped, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Threading.Overlapped.dll'
------------------
Resolver: 'System.Threading.ThreadPool, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Threading.ThreadPool, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Threading.ThreadPool.dll'
------------------
Resolver: 'System.Threading.Tasks.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Threading.Tasks.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Threading.Tasks.Parallel.dll'
------------------
Resolver: 'System.Transactions.Local, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Transactions.Local, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Transactions.Local.dll'
------------------
Resolver: 'System.Web.HttpUtility, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Foi encontrado um assembly: 'System.Web.HttpUtility, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Web.HttpUtility.dll'
------------------
Resolver: 'System.Xml.ReaderWriter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Xml.ReaderWriter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Xml.ReaderWriter.dll'
------------------
Resolver: 'System.Xml.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Xml.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Xml.XDocument.dll'
------------------
Resolver: 'System.Xml.XmlSerializer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Xml.XmlSerializer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Xml.XmlSerializer.dll'
------------------
Resolver: 'System.Xml.XPath.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Xml.XPath.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Xml.XPath.XDocument.dll'
------------------
Resolver: 'System.Xml.XPath, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Foi encontrado um assembly: 'System.Xml.XPath, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Carregar de: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.7\ref\net6.0\System.Xml.XPath.dll'
#endif


