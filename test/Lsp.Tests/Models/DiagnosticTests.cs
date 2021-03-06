﻿using System;
using FluentAssertions;
using Newtonsoft.Json;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using Xunit;

namespace Lsp.Tests.Models
{
    public class DiagnosticTests
    {
        [Theory, JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = new Diagnostic() {
                Code = new DiagnosticCode("abcd"),
                Message = "message",
                Range = new Range(new Position(1, 1), new Position(2, 2)),
                Severity = DiagnosticSeverity.Error,
                Source = "csharp"
            };
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = JsonConvert.DeserializeObject<Diagnostic>(expected);
            deresult.ShouldBeEquivalentTo(model);
        }

        [Theory, JsonFixture]
        public void OptionalTest(string expected)
        {
            var model = new Diagnostic();
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = JsonConvert.DeserializeObject<Diagnostic>(expected);
            deresult.ShouldBeEquivalentTo(model);
        }
    }
}
