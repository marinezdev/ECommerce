using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using conekta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ECommerce.Controllers
{
    public class MetodoPagoController : Controller
    {
        // GET: MetodoPago
        public ActionResult Index(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                string clave = "";

                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                string TotalText = "0.0";
                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                }
                string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                            //String s = String.Format("{0:#,##0.##}", Precio);
                ViewBag.Total = s;
                ViewBag.ListaArticulos = Lista;
                ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }
            
        }

        public ActionResult OxxoPay(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                string clave = "";

                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                string TotalText = "0.0";
                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                }
                string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                            //String s = String.Format("{0:#,##0.##}", Precio);
                ViewBag.Total = s;
                ViewBag.ListaArticulos = Lista;
                ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }

        }

        public ActionResult OxxoReferencia(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones, Application.Venta venta)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                //Calculate an expiration time
                DateTime thirtyDaysFromNowDateTime = DateTime.Now.AddDays(30);
                long thirtyDaysFromNowUnixTimestamp = (Int64)(thirtyDaysFromNowDateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                String thirtyDaysFromNow = thirtyDaysFromNowUnixTimestamp.ToString();

                conekta.Api.apiKey = "key_ma9rrrssyWVNwGzPgs3Gbg";
                conekta.Api.version = "2.0.0";

                try
                {
                    List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                    Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                    string clave = "";

                    clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                    Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                    usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                    string TotalText = "0.0";
                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                    
                    List<lineItems> lineItems = new List<lineItems>();
                    var Email = usuarios_Direcciones1.Correo;
                    var direccion = usuarios_Direcciones1.Estado + ", " + usuarios_Direcciones1.Poblacion + ", " + usuarios_Direcciones1.Colonia + ", " + usuarios_Direcciones1.CP + ", " + usuarios_Direcciones1.Calle + ", " + usuarios_Direcciones1.NumExterior + ", " + usuarios_Direcciones1.NumInteriror;
                    //var CP = direccion1.CP;

                    foreach (var dt in Lista)
                    {
                        int x = Convert.ToInt32(Convert.ToDouble(dt.Precio));

                        lineItems.Add(new lineItems()
                        {
                            name = dt.Nombre,
                            unit_price = Convert.ToInt32(x),
                            quantity = dt.Item,
                        });
                    }

                    var shipping_lines = new[]
                    {
                        new
                        {
                            amount = 0,
                            carrier = "ASAE CONSULTORES",
                        }
                    };

                    var customerInfo = new
                    {
                        name = usuarios_Direcciones1.Nombre + " " + usuarios_Direcciones1.ApellidoPaterno + " "+ usuarios_Direcciones1.ApellidoMaterno,
                        email = Email,
                        phone = usuarios_Direcciones1.Telefono,
                    };

                    var address = new
                    {
                        street1 = direccion,
                        postal_code = usuarios_Direcciones1.CP,
                        country = "MX",
                    };

                    var shipping_contact = new
                    {
                        address = address
                    };

                    var payment_method = new
                    {
                        type = "oxxo_cash",
                        expires_at = thirtyDaysFromNow
                    };

                    var charges = new[]
                    {
                        new
                        {
                            payment_method = payment_method
                        }

                    };


                    var orderData = new
                    {
                        line_items = lineItems,
                        shipping_lines = shipping_lines,
                        currency = "MXN",
                        customer_info = customerInfo,
                        shipping_contact = shipping_contact,
                        charges = charges,
                    };

                    string _orderDataWithCheckout = JsonConvert.SerializeObject(orderData);


                    //conekta.Order order = new conekta.Order().create(orderData.ToString());
                    conekta.Order order = new conekta.Order().create(_orderDataWithCheckout);

                    Charge charge = (Charge)order.charges.at(0);
                    LineItem line_item = (LineItem)order.line_items.at(0);

                    Console.WriteLine("ID: " + order.id);
                    Console.WriteLine("Payment Method: " + charge.payment_method.service_name);
                    Console.WriteLine("Reference: " + charge.payment_method.reference);
                    Console.WriteLine("$" + (order.amount / 100) + order.currency);
                    Console.WriteLine("Order");
                    Console.WriteLine(line_item.quantity + " - "
                                + line_item.name + " - "
                                + (line_item.unit_price / 100));



                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;
                    ViewBag.Referencia = charge.payment_method.reference;

                    //// EJECUTAR REGISTRO DE COMPRA
                    Models.Venta NewVenta = new Models.Venta();
                    NewVenta.IdUsuario = usuarios_Direcciones1.Id;
                    NewVenta.IdDireccion = usuarios_Direcciones1.IdDireccion;
                    NewVenta.IdMetoPago = 2;
                    NewVenta.Referencia = charge.payment_method.reference;
                    NewVenta.Total = Precio;
                    NewVenta.Clave = clave;
                    Models.Venta_Consultar venta_Consultar = venta.SPNuevaVenta(NewVenta);
                    ViewBag.Folio = venta_Consultar.Folio;

                    //// REGISTRO ARTICULOS A LA VENTA 
                    foreach (var dt in Lista)
                    {
                        dt.Id = venta_Consultar.Id;
                        venta.Venta_Articulos_Agregar(dt);
                    }

                    Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                    Session["SesionInvitacion"] = null;

                    //// ENVIO DE CORREO ELECTRONICO
                    Application.Correo.NuevaVenta nuevaVenta = new Application.Correo.NuevaVenta();
                    nuevaVenta.CorreoNuevaCompra(usuarios_Direcciones1, Lista, NewVenta, venta_Consultar, s);

                }
                catch (ConektaException e)
                {
                    foreach (JObject obj in e.details)
                    {
                        System.Console.WriteLine("\n [ERROR]:\n");
                        System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                        System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                        System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                    }
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }
        }


        public ActionResult SPEI(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                string clave = "";

                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                string TotalText = "0.0";
                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                }
                string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                            //String s = String.Format("{0:#,##0.##}", Precio);
                ViewBag.Total = s;
                ViewBag.ListaArticulos = Lista;
                ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }
        }

        public ActionResult SPEIReferencia(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones, Application.Venta venta)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                //Calculate an expiration time
                DateTime thirtyDaysFromNowDateTime = DateTime.Now.AddDays(30);
                long thirtyDaysFromNowUnixTimestamp = (Int64)(thirtyDaysFromNowDateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                String thirtyDaysFromNow = thirtyDaysFromNowUnixTimestamp.ToString();

                conekta.Api.apiKey = "key_ma9rrrssyWVNwGzPgs3Gbg";
                conekta.Api.version = "2.0.0";

                try
                {
                    List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                    Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                    string clave = "";

                    clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                    Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                    usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                    string TotalText = "0.0";
                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format

                    List<lineItems> lineItems = new List<lineItems>();
                    var Email = usuarios_Direcciones1.Correo;
                    var direccion = usuarios_Direcciones1.Estado + ", " + usuarios_Direcciones1.Poblacion + ", " + usuarios_Direcciones1.Colonia + ", " + usuarios_Direcciones1.CP + ", " + usuarios_Direcciones1.Calle + ", " + usuarios_Direcciones1.NumExterior + ", " + usuarios_Direcciones1.NumInteriror;
                    //var CP = direccion1.CP;

                    foreach (var dt in Lista)
                    {
                        int x = Convert.ToInt32(Convert.ToDouble(dt.Precio));

                        lineItems.Add(new lineItems()
                        {
                            name = dt.Nombre,
                            unit_price = Convert.ToInt32(x),
                            quantity = dt.Item,
                        });
                    }

                    var shipping_lines = new[]
                    {
                        new
                        {
                            amount = 0,
                            carrier = "ASAE CONSULTORES",
                        }
                    };

                    var customerInfo = new
                    {
                        name = usuarios_Direcciones1.Nombre + " " + usuarios_Direcciones1.ApellidoPaterno + " " + usuarios_Direcciones1.ApellidoMaterno,
                        email = Email,
                        phone = usuarios_Direcciones1.Telefono,
                    };

                    var address = new
                    {
                        street1 = direccion,
                        postal_code = usuarios_Direcciones1.CP,
                        country = "MX",
                    };

                    var shipping_contact = new
                    {
                        address = address
                    };

                    var payment_method = new
                    {
                        type = "spei",
                        expires_at = thirtyDaysFromNow
                    };

                    var charges = new[]
                    {
                        new
                        {
                            payment_method = payment_method
                        }

                    };


                    var orderData = new
                    {
                        line_items = lineItems,
                        shipping_lines = shipping_lines,
                        currency = "MXN",
                        customer_info = customerInfo,
                        shipping_contact = shipping_contact,
                        charges = charges,
                    };

                    string _orderDataWithCheckout = JsonConvert.SerializeObject(orderData);


                    //conekta.Order order = new conekta.Order().create(orderData.ToString());
                    conekta.Order order = new conekta.Order().create(_orderDataWithCheckout);

                    Charge charge = (Charge)order.charges.at(0);
                    LineItem line_item = (LineItem)order.line_items.at(0);

                    Console.WriteLine("ID: " + order.id);
                    Console.WriteLine("Payment Method: " + charge.payment_method.service_name);
                    Console.WriteLine("Reference: " + charge.payment_method.receiving_account_number);
                    Console.WriteLine("$" + (order.amount / 100) + order.currency);
                    Console.WriteLine("Order");
                    Console.WriteLine(line_item.quantity + " - "
                                + line_item.name + " - "
                                + (line_item.unit_price / 100));



                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;
                    ViewBag.Bank = charge.payment_method.receiving_account_bank;
                    ViewBag.Referencia = charge.payment_method.receiving_account_number;

                    //// EJECUTAR REGISTRO DE COMPRA
                    Models.Venta NewVenta = new Models.Venta();
                    NewVenta.IdUsuario = usuarios_Direcciones1.Id;
                    NewVenta.IdDireccion = usuarios_Direcciones1.IdDireccion;
                    NewVenta.IdMetoPago = 1002; // es el ID que aparece en base de datos modificar al nombre
                    NewVenta.Referencia = charge.payment_method.receiving_account_number;
                    NewVenta.Total = Precio;
                    NewVenta.Clave = clave;
                    Models.Venta_Consultar venta_Consultar = venta.SPNuevaVenta(NewVenta);
                    ViewBag.Folio = venta_Consultar.Folio;

                    //// REGISTRO ARTICULOS A LA VENTA 
                    foreach (var dt in Lista)
                    {
                        dt.Id = venta_Consultar.Id;
                        venta.Venta_Articulos_Agregar(dt);
                    }

                    Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                    Session["SesionInvitacion"] = null;
                    //// ENVIO DE CORREO ELECTRONICO
                    //// ENVIO DE CORREO ELECTRONICO
                    Application.Correo.NuevaVenta nuevaVenta = new Application.Correo.NuevaVenta();
                    nuevaVenta.CorreoNuevaCompra(usuarios_Direcciones1, Lista, NewVenta, venta_Consultar, s);
                }
                catch (ConektaException e)
                {
                    foreach (JObject obj in e.details)
                    {
                        System.Console.WriteLine("\n [ERROR]:\n");
                        System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                        System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                        System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                    }
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }
        }

        public ActionResult Paypal(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                string clave = "";

                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                string TotalText = "0.0";
                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                }
                string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                            //String s = String.Format("{0:#,##0.##}", Precio);
                ViewBag.Total = s;
                ViewBag.TotalT = Precio;
                ViewBag.ListaArticulos = Lista;
                ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }

        }

        public ActionResult PaypalReferencia(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones, Application.Venta venta)
        {
            if (Request.Cookies["Carrito"] != null)
            {

                try
                {
                    List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                    Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                    string clave = "";

                    clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                    Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                    usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                    string TotalText = "0.0";
                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format

                    List<lineItems> lineItems = new List<lineItems>();
                    var Email = usuarios_Direcciones1.Correo;
                    var direccion = usuarios_Direcciones1.Estado + ", " + usuarios_Direcciones1.Poblacion + ", " + usuarios_Direcciones1.Colonia + ", " + usuarios_Direcciones1.CP + ", " + usuarios_Direcciones1.Calle + ", " + usuarios_Direcciones1.NumExterior + ", " + usuarios_Direcciones1.NumInteriror;
                    //var CP = direccion1.CP;

                  
                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                    //// EJECUTAR REGISTRO DE COMPRA
                    Models.Venta NewVenta = new Models.Venta();
                    NewVenta.IdUsuario = usuarios_Direcciones1.Id;
                    NewVenta.IdDireccion = usuarios_Direcciones1.IdDireccion;
                    NewVenta.IdMetoPago = 1; // es el ID que aparece en base de datos modificar al nombre
                    NewVenta.Referencia = "";
                    NewVenta.Total = Precio;
                    NewVenta.Clave = clave;
                    Models.Venta_Consultar venta_Consultar = venta.SPNuevaVenta(NewVenta);
                    ViewBag.Folio = venta_Consultar.Folio;

                    //// REGISTRO ARTICULOS A LA VENTA 
                    foreach (var dt in Lista)
                    {
                        dt.Id = venta_Consultar.Id;
                        venta.Venta_Articulos_Agregar(dt);
                    }

                    Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                    Session["SesionInvitacion"] = null;
                    //// ENVIO DE CORREO ELECTRONICO

                }
                catch (ConektaException e)
                {
                    foreach (JObject obj in e.details)
                    {
                        System.Console.WriteLine("\n [ERROR]:\n");
                        System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                        System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                        System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                    }
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }
        }



        public ActionResult Checkout(Application.Carro_Electronico carro_Electronico, Application.Usuarios_Direcciones usuarios_Direcciones)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                Models.Usuarios_Direcciones usuarios_Direcciones1 = new Models.Usuarios_Direcciones();
                string clave = "";

                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
                usuarios_Direcciones1 = usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(clave);

                string TotalText = "0.0";
                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
                }
                string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                            //String s = String.Format("{0:#,##0.##}", Precio);
                ViewBag.Total = s;
                ViewBag.ListaArticulos = Lista;
                ViewBag.Usuarios_Direcciones = usuarios_Direcciones1;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Compra_Direccion");
            }

        }


        
        public class Item
        {
            public string name { get; set; }
            public int unit_price { get; set; }
            public int quantity { get; set; }
        }

        public class lineItems
        {
            public string name { get; set; }
            public int unit_price { get; set; }
            public int quantity { get; set; }
        }


        
    }
}
