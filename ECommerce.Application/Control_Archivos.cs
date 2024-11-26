using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Application
{
    public class Control_Archivos
    {
        Data.Control_Archivos _Archivos = new Data.Control_Archivos();
        public Models.ArticuloImg NuevoArchivo(HttpPostedFile Archivo, string DirectorioUsuario, string DirectorioURL)
        {
            Models.ArticuloImg _inmueblesImg = new Models.ArticuloImg();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".jpg".Contains(FileExtension) ^ ".png".Contains(FileExtension) ^ ".jpeg".Contains(FileExtension))
            {

                Models.Control_Archivos archivo = _Archivos.NuevoArchivo();
                string NombreArchivo = archivo.Id.ToString().PadLeft(12, '0');

                Image image = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 900, 600);
                image.Save(DirectorioUsuario + NombreArchivo + ".png");

                _inmueblesImg.IdArchivo = archivo.Id;
                _inmueblesImg.NmArchivo = NombreArchivo + ".png";
                _inmueblesImg.NmOriginal = Archivo.FileName;
                _inmueblesImg.Activo = 1;
                _inmueblesImg.ImagenURL = DirectorioURL + NombreArchivo + ".png";

            }

            return _inmueblesImg;
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.MakeTransparent();
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);

                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.MakeTransparent();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Png);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        public Models.ArticuloImg RotarImagen(string DirectorioUsuario, string NmArchivo, string DirectorioURL)
        {
            string extencion = NmArchivo.Split('.')[1];
            Models.Control_Archivos archivo = _Archivos.NuevoArchivo();
            string NombreArchivo = archivo.Id.ToString().PadLeft(12, '0');

            Image img = Image.FromFile(DirectorioUsuario + NmArchivo, true);

            Image image2 = ResizeImage(RotateImage(img), 900, 600);
            image2.Save(DirectorioUsuario + NombreArchivo + "." + extencion);

            Models.ArticuloImg _inmueblesImg = new Models.ArticuloImg();
            _inmueblesImg.IdArchivo = archivo.Id;
            _inmueblesImg.NmArchivo = NombreArchivo + "." + extencion;
            _inmueblesImg.NmOriginal = NombreArchivo + "." + extencion;
            _inmueblesImg.Activo = 1;
            _inmueblesImg.ImagenURL = DirectorioURL + NombreArchivo + "." + extencion;

            return _inmueblesImg;
        }

        public static Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {

                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);

            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bmp;
        }
    }
}
