#pragma checksum "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6b5b82ca99e7356bb38ee576b94457b3f750a7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_FullVehicleInventory), @"mvc.1.0.view", @"/Views/Vehicle/FullVehicleInventory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vehicle/FullVehicleInventory.cshtml", typeof(AspNetCore.Views_Vehicle_FullVehicleInventory))]
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
#line 1 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\_ViewImports.cshtml"
using TruVoyageMVCLayer;

#line default
#line hidden
#line 2 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\_ViewImports.cshtml"
using TruVoyageMVCLayer.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6b5b82ca99e7356bb38ee576b94457b3f750a7f", @"/Views/Vehicle/FullVehicleInventory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f1c3270dc5b51fb435c68b891bacb78a533904", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_FullVehicleInventory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TruVoyageDataOjectLayer.Vehicle>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewVehicleToInventory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
  
    ViewData["Title"] = "FullVehicleInventory";

#line default
#line hidden
            BeginContext(111, 48, true);
            WriteLiteral("\r\n<h2>FullVehicleInventoryView</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(159, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cf9b52626b5469995a35c5827db796d", async() => {
                BeginContext(200, 15, true);
                WriteLiteral("Add New Vehicle");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(219, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(312, 39, false);
#line 16 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.VIN));

#line default
#line hidden
            EndContext();
            BeginContext(351, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(407, 40, false);
#line 19 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.Make));

#line default
#line hidden
            EndContext();
            BeginContext(447, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(503, 41, false);
#line 22 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(544, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(600, 45, false);
#line 25 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.ModelYear));

#line default
#line hidden
            EndContext();
            BeginContext(645, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(701, 49, false);
#line 28 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleTypeID));

#line default
#line hidden
            EndContext();
            BeginContext(750, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(806, 50, false);
#line 31 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleClassID));

#line default
#line hidden
            EndContext();
            BeginContext(856, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(912, 41, false);
#line 34 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
            EndContext();
            BeginContext(953, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1009, 43, false);
#line 37 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.Mileage));

#line default
#line hidden
            EndContext();
            BeginContext(1052, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1108, 46, false);
#line 40 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.EngineSize));

#line default
#line hidden
            EndContext();
            BeginContext(1154, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1210, 53, false);
#line 43 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.PassengerCapacity));

#line default
#line hidden
            EndContext();
            BeginContext(1263, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1319, 45, false);
#line 46 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.Available));

#line default
#line hidden
            EndContext();
            BeginContext(1364, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1420, 52, false);
#line 49 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.NeedsMaintenance));

#line default
#line hidden
            EndContext();
            BeginContext(1472, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1528, 51, false);
#line 52 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
           Write(Html.DisplayNameFor(model => model.LastMaintenance));

#line default
#line hidden
            EndContext();
            BeginContext(1579, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 58 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1714, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1775, 38, false);
#line 62 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.VIN));

#line default
#line hidden
            EndContext();
            BeginContext(1813, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1881, 39, false);
#line 65 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Make));

#line default
#line hidden
            EndContext();
            BeginContext(1920, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1988, 40, false);
#line 68 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Model));

#line default
#line hidden
            EndContext();
            BeginContext(2028, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2096, 44, false);
#line 71 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.ModelYear));

#line default
#line hidden
            EndContext();
            BeginContext(2140, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2208, 48, false);
#line 74 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleTypeID));

#line default
#line hidden
            EndContext();
            BeginContext(2256, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2324, 49, false);
#line 77 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleClassID));

#line default
#line hidden
            EndContext();
            BeginContext(2373, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2441, 40, false);
#line 80 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Color));

#line default
#line hidden
            EndContext();
            BeginContext(2481, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2549, 42, false);
#line 83 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Mileage));

#line default
#line hidden
            EndContext();
            BeginContext(2591, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2659, 45, false);
#line 86 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.EngineSize));

#line default
#line hidden
            EndContext();
            BeginContext(2704, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2772, 52, false);
#line 89 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.PassengerCapacity));

#line default
#line hidden
            EndContext();
            BeginContext(2824, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2892, 44, false);
#line 92 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Available));

#line default
#line hidden
            EndContext();
            BeginContext(2936, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3004, 51, false);
#line 95 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.NeedsMaintenance));

#line default
#line hidden
            EndContext();
            BeginContext(3055, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3123, 50, false);
#line 98 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.DisplayFor(modelItem => item.LastMaintenance));

#line default
#line hidden
            EndContext();
            BeginContext(3173, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3241, 106, false);
#line 101 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.ActionLink("UpdateVehicleMaintenanceStatus", "UpdateVehicleMaintenanceStatus", new { id = item.VIN }));

#line default
#line hidden
            EndContext();
            BeginContext(3347, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(3372, 60, false);
#line 102 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.VIN }));

#line default
#line hidden
            EndContext();
            BeginContext(3432, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(3457, 101, false);
#line 103 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
               Write(Html.ActionLink("Remove Vehicle From Inventory", "RemoveVehicleFromInventory", new { id = item.VIN }));

#line default
#line hidden
            EndContext();
            BeginContext(3558, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 106 "C:\Users\Victor\Desktop\TruVoyage\TruVoyageMVCLayer\Views\Vehicle\FullVehicleInventory.cshtml"
        }

#line default
#line hidden
            BeginContext(3613, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TruVoyageDataOjectLayer.Vehicle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
