#pragma checksum "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fdcb759ea88aeb5236d19a7070d1dd7c8a62ec2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Manage_Order), @"mvc.1.0.view", @"/Views/Admin/Manage_Order.cshtml")]
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
#line 1 "C:\websample\Main project\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\websample\Main project\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fdcb759ea88aeb5236d19a7070d1dd7c8a62ec2", @"/Views/Admin/Manage_Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Manage_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce.Models.order_Details>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/Manage_Order"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Order_Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
  
    ViewData["Title"] = "Manage Order";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Manage Order</h1>\r\n\r\n<!-- Filter & Search Form -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fdcb759ea88aeb5236d19a7070d1dd7c8a62ec24929", async() => {
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <input type=\"text\" class=\"form-control\" name=\"searchString\" placeholder=\"Search by Name, Email, or Phone\"");
                BeginWriteAttribute("value", " value=\"", 351, "\"", 380, 1);
#nullable restore
#line 11 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
WriteAttributeValue("", 359, ViewBag.SearchString, 359, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
        <input type=""submit"" value=""Search"" class=""btn btn-default"" />
    </div>

    <!-- Status Filter Buttons -->
    <div class=""btn-group mb-3"" role=""group"" aria-label=""Order Status Filter"">
        <button type=""submit"" class=""btn btn-primary"" name=""orderStatus"" value=""In_Process"" ");
#nullable restore
#line 17 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                                        Write(ViewBag.OrderStatus == "In_Process" ? "active" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">In Process</button>\r\n        <button type=\"submit\" class=\"btn btn-secondary\" name=\"orderStatus\" value=\"pending\" ");
#nullable restore
#line 18 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                                       Write(ViewBag.OrderStatus == "Pending" ? "active" : "Pending");

#line default
#line hidden
#nullable disable
                WriteLiteral(">Payment Pending</button>\r\n        <button type=\"submit\" class=\"btn btn-success\" name=\"orderStatus\" value=\"Completed\" ");
#nullable restore
#line 19 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                                       Write(ViewBag.OrderStatus == "Completed" ? "active" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">Completed</button>\r\n        <button type=\"submit\" class=\"btn btn-danger\" name=\"orderStatus\" value=\"Rejected\" ");
#nullable restore
#line 20 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                                     Write(ViewBag.OrderStatus == "Rejected" ? "active" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">Rejected</button>\r\n        <button type=\"submit\" class=\"btn btn-info\" name=\"orderStatus\" value=\"All\" ");
#nullable restore
#line 21 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                              Write(ViewBag.OrderStatus == "All" ? "active" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">All</button>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Order List Table -->\r\n<table class=\"table table-striped mt-3\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 29 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 30 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 31 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 32 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 33 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().Order_Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 34 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
           Write(Html.DisplayNameFor(model => model.First().Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>Actions</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 42 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 45 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 46 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.Order_Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 47 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fdcb759ea88aeb5236d19a7070d1dd7c8a62ec213231", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                 WriteLiteral(item.Register_Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 52 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<!-- Pagination -->\r\n<nav aria-label=\"Page navigation\">\r\n    <ul class=\"pagination\">\r\n");
#nullable restore
#line 59 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
         for (int i = 1; i <= Math.Ceiling((double)ViewBag.TotalCount / ViewBag.PageSize); i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 2935, "\"", 2989, 2);
            WriteAttributeValue("", 2943, "page-item", 2943, 9, true);
#nullable restore
#line 61 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
WriteAttributeValue(" ", 2952, ViewBag.Page == i ? "active" : "", 2953, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3029, "\"", 3112, 6);
            WriteAttributeValue("", 3036, "?page=", 3036, 6, true);
#nullable restore
#line 62 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
WriteAttributeValue("", 3042, i, 3042, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3044, "&searchString=", 3044, 14, true);
#nullable restore
#line 62 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
WriteAttributeValue("", 3058, ViewBag.SearchString, 3058, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3079, "&orderStatus=", 3079, 13, true);
#nullable restore
#line 62 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
WriteAttributeValue("", 3092, ViewBag.OrderStatus, 3092, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
                                                                                                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </li>\r\n");
#nullable restore
#line 64 "C:\websample\Main project\Ecommerce\Views\Admin\Manage_Order.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</nav>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce.Models.order_Details>> Html { get; private set; }
    }
}
#pragma warning restore 1591
