using System.Web;
using System.Web.Optimization;

namespace ASPClientSchoolApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //added later
            bundles.Add(new StyleBundle("~/Inspiana_Common_CSS").Include(
                      "~/Content/Inspiana/css/bootstrap.min.css",//c
                      "~/Content/Inspiana/font-awesome/css/font-awesome.css",//c
                      "~/Content/Inspiana/css/animate.css",//c
                      "~/Content/Inspiana/css/style.css",//c
                      //extra for datatable
                      "~/Content/Inspiana/css/plugins/dataTables/datatables.min.css",//c*
                      //extra for icheck
                      "~/Content/Inspiana/css/plugins/iCheck/custom.css"//c*


                      ));

               //for dashboard 4_1
               bundles.Add(new StyleBundle("~/Inspiana_Dashboard_CSS").Include(
                      "~/Content/Inspiana/css/plugins/morris/morris-0.4.3.min.css"
                      ));
            //for form
            bundles.Add(new StyleBundle("~/Inspiana_Form_CSS").Include(
                   //file upload
                   "~/Content/Inspiana/css/plugins/dropzone/basic.css",
                   "~/Content/Inspiana/css/plugins/dropzone/dropzone.css",
                   "~/Content/Inspiana/css/plugins/jasny/jasny-bootstrap.min.css",
                   "~/Content/Inspiana/css/plugins/codemirror/codemirror.css",
                   //form advance
                   "~/Content/Inspiana/css/plugins/chosen/bootstrap-chosen.css",
                   "~/Content/Inspiana/css/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css",
                   "~/Content/Inspiana/css/plugins/colorpicker/bootstrap-colorpicker.min.css",
                   "~/Content/Inspiana/css/plugins/cropper/cropper.min.css",
                   "~/Content/Inspiana/css/plugins/switchery/switchery.css",
                   "~/Content/Inspiana/css/plugins/jasny/jasny-bootstrap.min.css",
                   "~/Content/Inspiana/css/plugins/nouslider/jquery.nouislider.css",
                   "~/Content/Inspiana/css/plugins/datapicker/datepicker3.css",
                   "~/Content/Inspiana/css/plugins/ionRangeSlider/ion.rangeSlider.css",
                   "~/Content/Inspiana/css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css",
                   "~/Content/Inspiana/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css",// also for #form basic
                   "~/Content/Inspiana/css/plugins/clockpicker/clockpicker.css",
                   "~/Content/Inspiana/css/plugins/daterangepicker/daterangepicker-bs3.css",
                   "~/Content/Inspiana/css/plugins/select2/select2.min.css",
                   "~/Content/Inspiana/css/plugins/touchspin/jquery.bootstrap-touchspin.min.css",
                   "~/Content/Inspiana/css/plugins/dualListbox/bootstrap-duallistbox.min.css"
                   ));



            bundles.Add(new ScriptBundle("~/Inspiana_Common_JS").Include(
                    "~/Content/Inspiana/js/jquery-3.1.1.min.js",//c
                    "~/Content/Inspiana/js/bootstrap.min.js",//c
                    //< !--MENU-- >
                    "~/Content/Inspiana/js/plugins/metisMenu/jquery.metisMenu.js",//c
                    "~/Content/Inspiana/js/plugins/slimscroll/jquery.slimscroll.min.js",//c

                    //Custom and plugin javascript
                    "~/Content/Inspiana/js/inspinia.js", //c
                    "~/Content/Inspiana/js/plugins/pace/pace.min.js",//c
                    //three extra js
                    //jQuery UI
                    "~/Content/Inspiana/js/plugins/jquery-ui/jquery-ui.min.js", //c*
                    //< !--iCheck-- >
                    "~/Content/Inspiana/js/plugins/iCheck/icheck.min.js", //c*
                    //DataTable
                    "~/Content/Inspiana/js/plugins/dataTables/datatables.min.js" //c*
                    ));

            bundles.Add(new ScriptBundle("~/Inspiana_Dashboard_JS").Include(

                    //Flot
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.js",
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.tooltip.min.js",
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.spline.js",
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.resize.js",
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.pie.js",
                    "~/Content/Inspiana/js/plugins/flot/jquery.flot.symbol.js",
                    "~/Content/Inspiana/js/plugins/flot/curvedLines.js",
                    //Peity
                    "~/Content/Inspiana/js/plugins/peity/jquery.peity.min.js",
                    "~/Content/Inspiana/js/demo/peity-demo.js",

                    //Jvectormap
                    "~/Content/Inspiana/js/plugins/jvectormap/jquery-jvectormap-2.0.2.min.js",
                    "~/Content/Inspiana/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                    //Sparkline
                    "~/Content/Inspiana/js/plugins/sparkline/jquery.sparkline.min.js",
                    //Sparkline demo data
                    "~/Content/Inspiana/js/demo/sparkline-demo.js",
                    //ChartJS
                    "~/Content/Inspiana/js/plugins/chartJs/Chart.min.js"
                    ));

            bundles.Add(new ScriptBundle("~/Inspiana_Form_JS").Include(
                    //< !--Chosen-- >
                    "~/Content/Inspiana/js/plugins/chosen/chosen.jquery.js",
                    //< !--JSKnob-- >
                    "~/Content/Inspiana/js/plugins/jsKnob/jquery.knob.js",
                    //< !--Input Mask-- >
                    "~/Content/Inspiana/js/plugins/jasny/jasny-bootstrap.min.js",
                    //< !--Data picker-- >
                    "~/Content/Inspiana/js/plugins/datapicker/bootstrap-datepicker.js",
                    //< !--NouSlider-- >

                    "~/Content/Inspiana/js/plugins/nouslider/jquery.nouislider.min.js",
                    //< !--Switchery-- >
                    "~/Content/Inspiana/js/plugins/switchery/switchery.js",
                    //< !--IonRangeSlider-- >                                                
                    "~/Content/Inspiana/js/plugins/ionRangeSlider/ion.rangeSlider.min.js",
                    //< !--Color picker-- >
                    "~/Content/Inspiana/js/plugins/colorpicker/bootstrap-colorpicker.min.js",
                    //< !--Clock picker-- >
                    "~/Content/Inspiana/js/plugins/clockpicker/clockpicker.js",
                    //< !--Image cropper-- >
                    "~/Content/Inspiana/js/plugins/cropper/cropper.min.js",
                    //< !--Date range use moment.js same as full calendar plugin -->
                    "~/Content/Inspiana/js/plugins/fullcalendar/moment.min.js",
                    //< !--Date range picker -->
                    "~/Content/Inspiana/js/plugins/daterangepicker/daterangepicker.js",
                    //< !--Select2-- >
                    "~/Content/Inspiana/js/plugins/select2/select2.full.min.js",
                    //< !--TouchSpin-- >
                    "~/Content/Inspiana/js/plugins/touchspin/jquery.bootstrap-touchspin.min.js",
                    //< !--Tags Input-- >
                    "~/Content/Inspiana/js/plugins/bootstrap-tagsinput/bootstrap-tagsinput.js",
                    //< !--Dual Listbox-- >
                    "~/Content/Inspiana/js/plugins/dualListbox/jquery.bootstrap-duallistbox.js",

                    //for file upload
                    //< !--Jasny-- >
                    "~/Content/Inspiana/js/plugins/jasny/jasny-bootstrap.min.js",

                    //< !--DROPZONE-- >
                    "~/Content/Inspiana/js/plugins/dropzone/dropzone.js",

                    //< !--CodeMirror-- >
                    "~/Content/Inspiana/js/plugins/codemirror/codemirror.js",
                    "~/Content/Inspiana/js/plugins/codemirror/mode/xml/xml.js"
                    ));



        }
    }
}
