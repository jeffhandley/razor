﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.LanguageServer.EndpointContracts;
using Microsoft.AspNetCore.Razor.LanguageServer.Protocol;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.VisualStudio.LanguageServer.Protocol;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Razor.LanguageServer.Formatting
{
    public class RazorDocumentOnTypeFormattingEndpointTest: FormattingLanguageServerTestBase
    {
        [Fact]
        public async Task Handle_OnTypeFormatting_FormattingDisabled_ReturnsNull()
        {
            // Arrange
            var uri = new Uri("file://path/test.razor");
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new DefaultRazorDocumentMappingService(LoggerFactory);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: false);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, EmptyDocumentResolver, formattingService, documentMappingService, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge { TextDocument = new TextDocumentIdentifier { Uri = uri, } };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_OnTypeFormatting_DocumentNotFound_ReturnsNull()
        {
            // Arrange
            var content = @"
@{
 if(true){}
}";
            var sourceMappings = new List<SourceMapping> { new SourceMapping(new SourceSpan(17, 0), new SourceSpan(17, 0)) };
            var codeDocument = CreateCodeDocument(content, sourceMappings);
            var uri = new Uri("file://path/test.razor");
            var documentResolver = CreateDocumentResolver("file://path/testDifferentFile.razor", codeDocument);
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new DefaultRazorDocumentMappingService(LoggerFactory);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: true);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, documentResolver, formattingService, documentMappingService, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge()
            {
                TextDocument = new TextDocumentIdentifier { Uri = uri, },
                Character = ".",
                Position = new Position(2, 11),
                Options = new FormattingOptions { InsertSpaces = true, TabSize = 4 }
            };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_OnTypeFormatting_RemapFailed_ReturnsNull()
        {
            // Arrange
            var content = @"
@{
 if(true){}
}";
            var sourceMappings = new List<SourceMapping> { };
            var codeDocument = CreateCodeDocument(content, sourceMappings);
            var uri = new Uri("file://path/test.razor");
            var documentResolver = CreateDocumentResolver(uri.GetAbsoluteOrUNCPath(), codeDocument);
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new DefaultRazorDocumentMappingService(LoggerFactory);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: true);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, documentResolver, formattingService, documentMappingService, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge()
            {
                TextDocument = new TextDocumentIdentifier { Uri = uri, },
                Character = ".",
                Position = new Position(2, 11),
                Options = new FormattingOptions { InsertSpaces = true, TabSize = 4 },
            };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_OnTypeFormatting_HtmlLanguageKind_ReturnsNull()
        {
            // Arrange
            var content = @"
@{
 if(true){}
}";
            var sourceMappings = new List<SourceMapping> { new SourceMapping(new SourceSpan(17, 0), new SourceSpan(17, 0)) };
            var codeDocument = CreateCodeDocument(content, sourceMappings);
            var uri = new Uri("file://path/test.razor");
            var documentResolver = CreateDocumentResolver(uri.GetAbsoluteOrUNCPath(), codeDocument);
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new Mock<RazorDocumentMappingService>(MockBehavior.Strict);
            documentMappingService.Setup(s => s.GetLanguageKind(codeDocument, 17, false)).Returns(RazorLanguageKind.Html);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: true);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, documentResolver, formattingService, documentMappingService.Object, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge()
            {
                TextDocument = new TextDocumentIdentifier { Uri = uri, },
                Character = "}",
                Position = new Position(2, 11),
                Options = new FormattingOptions { InsertSpaces = true, TabSize = 4 },
            };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_OnTypeFormatting_RazorLanguageKind_ReturnsNull()
        {
            // Arrange
            var content = @"
@{
 if(true){}
}";
            var sourceMappings = new List<SourceMapping> { new SourceMapping(new SourceSpan(17, 0), new SourceSpan(17, 0)) };
            var codeDocument = CreateCodeDocument(content, sourceMappings);
            var uri = new Uri("file://path/test.razor");
            var documentResolver = CreateDocumentResolver(uri.GetAbsoluteOrUNCPath(), codeDocument);
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new Mock<RazorDocumentMappingService>(MockBehavior.Strict);
            documentMappingService.Setup(s => s.GetLanguageKind(codeDocument, 17, false)).Returns(RazorLanguageKind.Razor);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: true);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, documentResolver, formattingService, documentMappingService.Object, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge()
            {
                TextDocument = new TextDocumentIdentifier { Uri = uri, },
                Character = "}",
                Position = new Position(2, 11),
                Options = new FormattingOptions { InsertSpaces = true, TabSize = 4 }
            };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_OnTypeFormatting_UnexpectedTriggerCharacter_ReturnsNull()
        {
            // Arrange
            var content = @"
@{
 if(true){}
}";
            var sourceMappings = new List<SourceMapping> { new SourceMapping(new SourceSpan(17, 0), new SourceSpan(17, 0)) };
            var codeDocument = CreateCodeDocument(content, sourceMappings);
            var uri = new Uri("file://path/test.razor");
            var documentResolver = CreateDocumentResolver(uri.GetAbsoluteOrUNCPath(), codeDocument);
            var formattingService = new TestRazorFormattingService();
            var documentMappingService = new DefaultRazorDocumentMappingService(LoggerFactory);
            var optionsMonitor = GetOptionsMonitor(enableFormatting: true);
            var endpoint = new RazorDocumentOnTypeFormattingEndpoint(
                Dispatcher, documentResolver, formattingService, documentMappingService, optionsMonitor, LoggerFactory);
            var @params = new DocumentOnTypeFormattingParamsBridge()
            {
                TextDocument = new TextDocumentIdentifier { Uri = uri, },
                Character = ".",
                Position = new Position(2, 11),
                Options = new FormattingOptions { InsertSpaces = true, TabSize = 4 }
            };

            // Act
            var result = await endpoint.Handle(@params, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
