using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace Capa_Negocio.Servicios
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> SubirImagen(IFormFile archivo)
        {
            using var stream = archivo.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(archivo.FileName, stream),
                Folder = "portal-articulos"
            };
            var resultado = await _cloudinary.UploadAsync(uploadParams);
            return resultado.SecureUrl.ToString();
        }
    }
}
