#pragma checksum "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef93e3fb11519d840da2294187b1cd8a1a9f55ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalaryEmps_Index), @"mvc.1.0.view", @"/Views/SalaryEmps/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\_ViewImports.cshtml"
using Enterprises_manufacturing_goods;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\_ViewImports.cshtml"
using Enterprises_manufacturing_goods.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef93e3fb11519d840da2294187b1cd8a1a9f55ba", @"/Views/SalaryEmps/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2707e6c6d16808444c382aecc4015d88140ae9d2", @"/Views/_ViewImports.cshtml")]
    public class Views_SalaryEmps_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Enterprises_manufacturing_goods.Models.SalaryEmp>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexCopyAdd", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark accept-policy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("frm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    body {
        font-size: 14px;
    }

    a {
        text-decoration: none;
        color: green;
    }

    h1 {
        font-weight: bold;
        font-family: 'Times New Roman', Times, serif;
    }

    .Back {
        font-size: 20px;
    }

    .allsumm, em {
        color: green;
    }
    .table {
       
    }
    /* .sub{
      width:auto;
      font-size:
        background-color:green;
        color:black;
    }*/
    .error {
        color: red;
        font-size: 25px;
        text-align: center;
    }
    .container,.table{
        margin-left:1%;
    }
    .ct{
        text-align:center;
        padding-left:25%;
        padding-top:60px;
    }
</style>

<div class=""ct"">
    <h1 class=""display-4"">Предприятия по производству кондитерских изделий</h1>
</div>
<br />
<style>
        .Error {
            color: red;
            font-size: 30px;
        }

    </style>

    <br />
    <div class=""Error"">
        <p>");
#nullable restore
#line 67 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
      Write(ViewBag.AddMessege);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <br />\r\n<h1>Зарплата</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef93e3fb11519d840da2294187b1cd8a1a9f55ba7656", async() => {
                WriteLiteral("\r\n    <p>\r\n        <main class=\"container-fluid pt-3\">\r\n            <div class=\"d-flex justify-content-end\">\r\n\r\n                <div class=\"row g-3\">\r\n                    ");
#nullable restore
#line 78 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
               Write(Html.DropDownList("yearString", ViewBag.Year as SelectList, "Выберите год", new { @id = "Ye", @class = "form-control", style = "width:auto;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                   \r\n                    <div class=\"col-auto\">\r\n                        ");
#nullable restore
#line 81 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DropDownList("monthString", ViewBag.Month as SelectList, "Выберите месяц", new { @id = "Mo", @class = "form-control", style = "width:auto;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                      \r\n                    </div>\r\n                   \r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef93e3fb11519d840da2294187b1cd8a1a9f55ba9185", async() => {
                    WriteLiteral("Выдать зарплату");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <div class=\"col-auto\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef93e3fb11519d840da2294187b1cd8a1a9f55ba10680", async() => {
                    WriteLiteral("Все записи");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n                </div>\r\n            <p></p>\r\n        </main>\r\n    </p>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script>



    $(""#Mo"").change(function () {
        $(""#Mo"").val = $(""#Mo"");
       
        let form = document.forms.frm
        form.submit();

    });

</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef93e3fb11519d840da2294187b1cd8a1a9f55ba13667", async() => {
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <table class=\"table\" align=\"left\">\r\n            <thead class=\"tbl\">\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 117 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 120 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Month));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 123 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Employee));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 126 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParticipationPurchase));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 129 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParticipationSale));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 132 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParticipationProduction));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 135 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.CountParticipation));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 138 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.SalaryEmployee));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 141 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Bonus));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 144 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.TotalAmount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 147 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Issued));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 154 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 158 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.YearNavigation.YearName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 161 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MonthNavigation.MonthName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 164 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EmployeeNavigation.Fullname));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 167 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParticipationPurchase));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 170 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParticipationSale));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 173 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParticipationProduction));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 176 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CountParticipation));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 179 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SalaryEmployee));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 183 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Bonus));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 186 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TotalAmount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 189 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Issued));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 193 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n    <div class=\"allsumm\">\r\n    <h4>Общая сумма всех сотрудников:  <em>");
#nullable restore
#line 199 "C:\Users\zenis\Рабочий стол\3-курс\6-сем\СУБД\Рабочая копия\Enterprises_manufacturing_goods\Enterprises_manufacturing_goods\Views\SalaryEmps\Index.cshtml"
                                      Write(ViewBag.Summa);

#line default
#line hidden
#nullable disable
                WriteLiteral("</em></h4>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Enterprises_manufacturing_goods.Models.SalaryEmp>> Html { get; private set; }
    }
}
#pragma warning restore 1591