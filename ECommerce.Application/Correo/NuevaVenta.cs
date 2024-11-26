using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Correo
{
    public class NuevaVenta
    {
        public Models.Mensaje CorreoNuevaCompra(Models.Usuarios_Direcciones usuarios_Direcciones1, List<Models.Carro_Electronico> Lista, Models.Venta NewVenta, Models.Venta_Consultar venta_Consultar, string precio)
        {
            Models.Mensaje mensaje = new Models.Mensaje();

            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", usuarios_Direcciones1.Correo.Trim(), "Asae Ecommerce", "Tu orden se encuentra en revisión folio:" + venta_Consultar.Folio, HTMLNuevaCompra(usuarios_Direcciones1, Lista, NewVenta, venta_Consultar, precio)) == "Correo enviado")
            {
                mensaje.Respuesta = true;
            }

            return mensaje;
        }

        public string HTMLNuevaCompra(Models.Usuarios_Direcciones usuarios_Direcciones1, List<Models.Carro_Electronico> Lista, Models.Venta NewVenta, Models.Venta_Consultar venta_Consultar, string precio)
        {
            string HTML = "<!DOCTYPE html>" +
                          "<html>" +
                          "  <head>" +
                          "      <title></title>" +
                          "      <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
                          "      <meta name='viewport' content='width=device-width, initial-scale=1'>" +
                          "      <meta http-equiv='X-UA-Compatible' content='IE=edge' />" +
                          "      <style type='text/css'>" +
                          "      </style>" +
                          "  </head>" +
                          "  <body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;'>" +
                          "      <!-- HIDDEN PREHEADER TEXT -->" +
                          "      <div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'>" +
                          "      </div>" +
                          "      <table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                          "          <!-- LOGO -->" +
                          "          <tr>" +
                          "              <td bgcolor='#ECECEC' align='center'>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "          <tr>" +
                          "              <td bgcolor='#ECECEC' align='center' style='padding: 0px 10px 0px 10px;'>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 3px; line-height: 48px;'>" +
                          "                              <br><br>" +
                          "                              <img src='https://tickets.asae.com.mx/Imagenes/LogoAsaeTikets.png' width='125' height='120' style='display: block; border: 0px;' />" +
                          "                              <h1 style='font-size: 20px; font-weight: 200; margin: 3; text-align: left; color: #015495;'>&nbsp;&nbsp; Hola!</h1> " +
                          "                              <h1 style='font-size: 30px; font-weight: 300; margin: 3; text-align: left; color: #015495;'>&nbsp;&nbsp; Tu pedido está en revisión</h1> " +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "          <tr>" +
                          "              <td bgcolor='#ffffff' align='center' style='padding: 0px 10px 0px 10px;'>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td width='40%' align='center' bgcolor='#ffffff'>" +
                          "                              <img src='https://www.asae.com.mx/01/relog_espera.png' width='180' height='180' style='display: block; border: 0px;' />" +
                          "                          <td>" +
                          "                          <td valign='middle' width='60%' bgcolor='#ffffff' style='padding: 20px 30px 40px 30px; color: #262626; font-size: 20px; font-weight: 400; line-height: 25px; font-family: 'Nunito Sans', sans-serif;'>" +
                          "                              <p style='margin: 0;'><strong> Estamos revisando tus datos para confirmar el pedido. </strong>  Si es necesario, te escribiremos por correo, por lo que es importante que nos respondas.</p>" +
                          "                              <br>" +
                          "                              <p style='margin: 0;'><strong> Ya que terminemos la revisión,  </strong> recibirás un correo de confirmación con los detalles de tu compra.</p>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "          <tr>" +
                          "              <td bgcolor='#ffffff' align='center' style='padding: 30px 10px 0px 10px;'>" +
                          "                   <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr> " +
                          "                          <td bgcolor='#ECECEC' align='center' style='padding: 2px 3px 4px 3px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                          "                              <h2 style='font-size: 16px; font-weight: 400; color: #111111; margin: 0;'><strong>Información de compra.</strong></h2>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td width='50%' align='center' bgcolor='#ffffff' style='border-bottom: 1px solid #000;'>" +
                          "                              <p style='margin: 0; font-size: 16px;'><strong> NÚMERO DE PEDIDO </strong>  </p>" +
                          "                          <td>" +
                          "                          <td width='50%' align='center' bgcolor='#ffffff'  style='border-bottom: 1px solid #000; padding: 10px 10px 10px 10px;'>" +
                          "                              <p style='margin: 0; font-size: 16px;'><strong> ESTATUS </strong> </p>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                       <tr>" +
                          "                          <td width='50%' align='center' bgcolor='#ffffff' style='padding: 10px 10px 10px 10px;'>" +
                          "                              <p style='margin: 0; font-size: 16px;'><strong> " + venta_Consultar.Folio +" </strong>  </p>" +
                          "                          <td>" +
                          "                          <td width='50%' align='center' bgcolor='#ffffff' style='padding: 10px 10px 10px 10px;'>" +
                          "                              <p style='margin: 0; font-size: 16px; color: #ff5722;'><strong>  Por confirmar </strong> </p>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "          <tr>" +
                          "              <td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td bgcolor='#ECECEC' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                          "                              <br><br>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "          <tr>" +
                          "              <td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                          "                  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                          "                      <tr>" +
                          "                          <td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;'> <br>" +
                          "                              <p style='margin: 0;'>Queda prohibida cualquier revisión, retransmisión, distribución o cualquier otro uso o acción relacionada con esta información, hecha por personas o entidades distintas a los destinatarios a los que ha sido dirigida.</p>" +
                          "                          </td>" +
                          "                      </tr>" +
                          "                  </table>" +
                          "              </td>" +
                          "          </tr>" +
                          "      </table>" +
                          "  </body>" +
                          "  </html>";



            return HTML;
        }
    }
}
