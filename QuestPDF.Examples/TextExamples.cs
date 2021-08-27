﻿using System.Linq;
using NUnit.Framework;
using QuestPDF.Examples.Engine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDF.Examples
{
    public class TextExamples
    {
        [Test]
        public void TextElements()
        {
            RenderingTest
                .Create()
                .PageSize(PageSizes.A4)
                .FileName()
                .ProducePdf()
                .ShowResults()
                .Render(container =>
                {
                    container
                        .Padding(20)
                        .Box()
                        .Border(1)
                        .Padding(5)
                        .Text(text =>
                        {
                            text.Span("Let's start with bold text. ", TextStyle.Default.Bold().BackgroundColor(Colors.Grey.Lighten3).Size(16));
                            text.Span("Then something bigger. ", TextStyle.Default.Size(28).Color(Colors.DeepOrange.Darken2).BackgroundColor(Colors.Yellow.Lighten3).Underlined());
                            text.Span("And tiny teeny-tiny. ", TextStyle.Default.Size(6));
                            text.Span("Stroked text also works fine. ", TextStyle.Default.Size(14).Stroked().BackgroundColor(Colors.Grey.Lighten4));
                               
                            text.Span("0123456789-0123456789-0123456789-0123456789-0123456789-0123456789-0123456789", TextStyle.Default.Size(18));
                            
                            text.NewLine();
                            text.Span("Is it time for lorem  ipsum? ", TextStyle.Default.Size(12).Underlined().BackgroundColor(Colors.Grey.Lighten3));
                            text.Span(Placeholders.LoremIpsum(), TextStyle.Default.Size(12));
                            
                            text.Span("Before element - ");
                            text.Element().PaddingBottom(-10).Background(Colors.Red.Lighten4).Height(20).PaddingHorizontal(5).AlignMiddle().Text("Text inside text", TextStyle.Default.Size(8));
                            text.Span(" - end of element.");
                            
                            text.NewLine();
                            // text.Span("And now some colors: ", TextStyle.Default.Size(16).Color(Colors.Green.Medium));
                            //
                            // foreach (var i in Enumerable.Range(1, 100))
                            // {
                            //     text.Span($"{i}: {Placeholders.Sentence()} ", TextStyle.Default.Size(12 + i / 5).LineHeight(2.75f - i / 50f).Color(Placeholders.Color()).BackgroundColor(Placeholders.BackgroundColor()));   
                            // }
                        });
                });
        }
    }
}