#pragma checksum "C:\Users\jpmsa\source\repos\Projeto\WebAPI\Views\ToDoItems\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bbafad5c8760086ea57768ae14bc76a2877a080"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ToDoItems_Edit), @"mvc.1.0.view", @"/Views/ToDoItems/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bbafad5c8760086ea57768ae14bc76a2877a080", @"/Views/ToDoItems/Edit.cshtml")]
    public class Views_ToDoItems_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebAPI.Models.ToDoItems>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jpmsa\source\repos\Projeto\WebAPI\Views\ToDoItems\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>ToDoItems</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Atividade_Id"" />
            <div class=""form-group"">
                <label asp-for=""Atividade_Titulo"" class=""control-label""></label>
                <input asp-for=""Atividade_Titulo"" class=""form-control"" />
                <span asp-validation-for=""Atividade_Titulo"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Atividade_Dia_Hora"" class=""control-label""></label>
                <input asp-for=""Atividade_Dia_Hora"" class=""form-control"" />
                <span asp-validation-for=""Atividade_Dia_Hora"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Atividade_DiaSemana"" class=""control-label""></label>
                <in");
            WriteLiteral(@"put asp-for=""Atividade_DiaSemana"" class=""form-control"" />
                <span asp-validation-for=""Atividade_DiaSemana"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Feito"" /> ");
#nullable restore
#line 33 "C:\Users\jpmsa\source\repos\Projeto\WebAPI\Views\ToDoItems\Edit.cshtml"
                                                                  Write(Html.DisplayNameFor(model => model.Feito));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\jpmsa\source\repos\Projeto\WebAPI\Views\ToDoItems\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAPI.Models.ToDoItems> Html { get; private set; }
    }
}
#pragma warning restore 1591