using System.Web;
using System.Web.Optimization;

namespace NCLS.WEB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include("~/Assets/plugins/jquery-1-12-4.js"));

            bundles.Add(new ScriptBundle("~/Scripts/common").Include(
                        "~/Assets/plugins/bootstrap/js/bootstrap.js",
                        "~/Assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js",
                        "~/Assets/plugins/jquery-slimscroll/jquery.slimscroll.js",
                        "~/Assets/plugins/jquery.blockui.js",
                        "~/Assets/plugins/uniform/jquery.uniform.js",
                        "~/Assets/plugins/bootstrap-switch/js/bootstrap-switch.js",

                        "~/Assets/plugins/datatables/datatables.js",
                        "~/Assets/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",
                        "~/Assets/plugins/datatables/plugins/buttons/1.3.1/js/buttons.html5.min.js",
                        "~/Assets/plugins/datatables/plugins/buttons/1.3.1/js/buttons.colVis.min.js",
                        "~/Assets/plugins/datatables/plugins/buttons/1.3.1/js/dataTables.buttons.min.js",
                        "~/Assets/plugins/datatables/plugins/jszip/3.1.3/jszip.min.js",

                        "~/Assets/scripts/app.js",
                        "~/Assets/scripts/layout.js",
                        "~/Assets/scripts/demo.js",
                        "~/Assets/scripts/validatetor.js",
                        "~/Assets/plugins/bootstrap-validator/js/validator.js",
                        "~/Assets/plugins/jstree/dist/jstree.js",
                        "~/Assets/scripts/quick-sidebar.js",
                        "~/Assets/plugins/bootbox/bootbox.js",
                        "~/Assets/plugins/clockface/js/clockface.js",
                        "~/Assets/plugins/bootstrap-fileinput/bootstrap-fileinput.js",
                        "~/Assets/plugins/jquery-minicolors/jquery.minicolors.js",

                        "~/Assets/plugins/amcharts/amcharts/amcharts.js",
                        "~/Assets/plugins/amcharts/amcharts/serial.js",
                        "~/Assets/plugins/amcharts/amcharts/pie.js",
                        "~/Assets/plugins/amcharts/amcharts/radar.js",
                        "~/Assets/plugins/amcharts/amcharts/plugins/dataloader/dataloader.js",
                        "~/Assets/plugins/amcharts/amcharts/themes/light.js",
                        "~/Assets/plugins/amcharts/amcharts/themes/patterns.js",
                        "~/Assets/plugins/amcharts/amcharts/themes/chalk.js",
                        "~/Assets/plugins/amcharts/ammap/ammap.js",
                        "~/Assets/plugins/amcharts/ammap/maps/js/worldLow.js",
                        "~/Assets/plugins/amcharts/amstockcharts/amstock.js",
                        "~/Assets/pages/scripts/charts-amcharts.js",

                        "~/Assets/plugins/bootstrap-switch/js/bootstrap-switch.js",

                        "~/Assets/plugins/globalize/globalize.js",
                        "~/Assets/plugins/globalize/globalize/currency.js",
                        "~/Assets/plugins/globalize/globalize/date.js",
                        "~/Assets/plugins/globalize/globalize/message.js",
                        "~/Assets/plugins/globalize/globalize/number.js",
                        "~/Assets/plugins/globalize/globalize/plural.js",
                        "~/Assets/plugins/globalize/globalize/relative-time.js",
                        "~/Assets/plugins/globalize/globalize/unit.js",

                        "~/Assets/_custom.js"));

            bundles.Add(new ScriptBundle("~/Scripts/datepicker").Include(
                "~/Assets/plugins/moment.js",
                "~/Assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"

            //"~/Assets/plugins/bootstrap-daterangepicker/moment.js",
            //"~/Assets/plugins/bootstrap-timepicker/js/bootstrap-timepicker.js",
            //"~/Assets/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
            //"~/Assets/scripts/pages/components-date-time-pickers.js",
            //"~/Assets/plugins/bootstrap-datepicker-thai/js/bootstrap-datepicker.js",
            //"~/Assets/plugins/datepicker/js/bootstrap-datepicker.js"));
            //"~/Assets/plugins/bootstrap-datepicker-thai/js/bootstrap-datepicker-thai.js",
            //"~/Assets/plugins/bootstrap-datepicker-thai/js/locales/bootstrap-datepicker.th.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/select2").Include(
                        "~/Assets/plugins/select2/js/select2.full.js",
                        "~/Assets/scripts/pages/components-select2.js"));

            bundles.Add(new StyleBundle("~/Contents/common").Include(
                        "~/Assets/plugins/font-awesome/css/font-awesome.css",
                        "~/Assets/plugins/simple-line-icons/simple-line-icons.css",
                        "~/Assets/plugins/bootstrap/css/bootstrap.css",
                        "~/Assets/plugins/uniform/css/uniform.default.css",
                        "~/Assets/plugins/bootstrap-switch/css/bootstrap-switch.css",
                        "~/Assets/plugins/datatables/datatables.css",
                        "~/Assets/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",
                        "~/Assets/css/components.css",
                        "~/Assets/css/plugins.css",
                        "~/Assets/css/layout.css",
                        "~/Assets/css/silver.css",
                        "~/Assets/plugins/bootstrap-fileinput/bootstrap-fileinput.css",
                        "~/Assets/plugins/jquery-minicolors/jquery.minicolors.css",
                        "~/Assets/plugins/jstree/dist/themes/default/style.css",
                        "~/Assets/plugins/bootstrap-switch/css/bootstrap-switch.css",
                        "~/Assets/_custom.css"));

            bundles.Add(new StyleBundle("~/Contents/datepicker").Include(
                        "~/Assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css",
                        "~/Assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.css"
                        //"~/Assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.css",
                        //"~/Assets/plugins/bootstrap-timepicker/css/bootstrap-timepicker.css",
                        //"~/Assets/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.css",
                        //"~/Assets/plugins/bootstrap-datepicker-thai/css/datepicker.css"
                        ));

            bundles.Add(new StyleBundle("~/Contents/select2").Include(
                        "~/Assets/plugins/select2/css/select2.css",
                        "~/Assets/plugins/select2/css/select2-bootstrap.css"));
        }
    }
}
