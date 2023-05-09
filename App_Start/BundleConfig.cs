using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace Safoa.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/simple-line-icons.min.css")
                .Include("~/Content/css/bootstrap-rtl.min.css")
                .Include("~/Content/css/bootstrap-switch-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/daterangepicker.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/morris.css", new CssRewriteUrlTransformAbsolute())
                 .Include("~/Content/css/fullcalendar.min.css", new CssRewriteUrlTransformAbsolute())
                  .Include("~/Content/css/jqvmap.css", new CssRewriteUrlTransformAbsolute())
                   .Include("~/Content/css/components-rounded-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                   .Include("~/Content/css/plugins-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                  .Include("~/Content/css/layout-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                    //.Include("~/Content/css/darkblue-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                    .Include("~/Content/css/custom-rtl.min.css", new CssRewriteUrlTransformAbsolute())
                      .Include("~/Content/css/datatables.min.css", new CssRewriteUrlTransformAbsolute())
                       .Include("~/Content/css/select2.min.css", new CssRewriteUrlTransformAbsolute())
                            .Include("~/Content/css/select2-bootstrap.min.css", new CssRewriteUrlTransformAbsolute())







                );

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/jquery.min.js")
                .Include("~/Content/js/bootstrap.min.js")
                .Include("~/Content/js/js.cookie.min.js")
                .Include("~/Content/js/jquery.slimscroll.min.js")
                .Include("~/Content/js/jquery.blockui.min.js")
                .Include("~/Content/bootstrap-switch.min.js")
                .Include("~/Content/js/moment.min.js")
                 .Include("~/Content/js/daterangepicker.min.js")
                  .Include("~/Content/js/morris.min.js")
                   .Include("~/Content/js/raphael-min.js")

                    .Include("~/Content/js/jquery.waypoints.min.js")
                     .Include("~/Content/js/jquery.counterup.min.js")
                                           .Include("~/Content/js/amcharts.js")
                      .Include("~/Content/js/serial.js")
                       .Include("~/Content/js/pie.js")
                        .Include("~/Content/js/radar.js")
                         .Include("~/Content/js/light.js")
                          .Include("~/Content/js/patterns.js")
                           .Include("~/Content/js/chalk.js")
                            .Include("~/Content/js/ammap.js")
                             .Include("~/Content/js/worldLow.js")
                              .Include("~/Content/js/amstock.js")
                                .Include("~/Content/js/fullcalendar.min.js")

                                     .Include("~/Content/js/horizontal-timeline.js")
                                          .Include("~/Content/js/jquery.flot.min.js")
                                               .Include("~/Content/js/jquery.flot.resize.min.js")
                                                    .Include("~/Content/js/jquery.flot.categories.min.js")

                                                       .Include("~/Content/js/jquery.easypiechart.min.js")
                                                          .Include("~/Content/js/jquery.sparkline.min.js")
                                                             .Include("~/Content/js/jquery.vmap.js")
                                                                .Include("~/Content/js/jquery.vmap.russia.js")

                .Include("~/Content/js/jquery.vmap.world.js")
                .Include("~/Content/js/jquery.vmap.europe.js")
                .Include("~/Content/js/jquery.vmap.germany.js")
                .Include("~/Content/js/jquery.vmap.usa.js")
                .Include("~/Content/js/jquery.vmap.sampledata.js")

                .Include("~/Content/js/jquery.validate.js")
                .Include("~/Content/js/jquery.validate.unobtrusive.js")
                  .Include("~/Content/js/jquery.validate.extend.js")


                .Include("~/Content/js/app.min.js")
                .Include("~/Content/js/dashboard.min.js")
                .Include("~/Content/js/layout.min.js")
                .Include("~/Content/js/demo.min.js")
                 .Include("~/Content/js/quick-sidebar.min.js")
                  .Include("~/Content/js/quick-sidebar.min.js")
                                    .Include("~/Content/js/quick-nav.min.js")

                  .Include("~/Content/js/datatables.all.min.js")




                      .Include("~/scripts/jquery-1.8.0.min.js")
                  .Include("~/scripts/jquery.unobtrusive-ajax.min.js")
                     .Include("~/Content/js/select2.full.min.js")
                    .Include("~/Content/js/components-select2.min.js")
                  //.Include("~/Content/js/form-validation-md.min.js")

                  );

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
