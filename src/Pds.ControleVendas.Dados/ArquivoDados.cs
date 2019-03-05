using Amazon;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pds.ControleVendas.Dados
{
	public class ArquivoDados
	{
		private readonly IAmazonS3 s3Client;

		public ArquivoDados(IAmazonS3 s3Client)
		{
			this.s3Client = s3Client;

			var options = new CredentialProfileOptions
			{
				AccessKey = "AKIAJQJV7TW2I5HDQDYQ",
				SecretKey = "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"
			};

			var profile = new Amazon.Runtime.CredentialManagement.CredentialProfile("profile", options);
			profile.Region = RegionEndpoint.USEast1;

			var netSDKFile = new NetSDKCredentialsFile();
			netSDKFile.RegisterProfile(profile);
		}

		public List<string> ListarArquivos()
		{
			var arquivos = new List<string>();

			var t = s3Client.GetAllObjectKeysAsync("controlevendas", "", null);

			Task.WaitAll(t);

			arquivos = new List<string>(t.Result);

			return arquivos;
		}
		public async Task<MemoryStream> GetArquivo(string key)
		{
			var response = await s3Client.GetObjectAsync(new Amazon.S3.Model.GetObjectRequest() { BucketName = "controlevendas", Key = key });

			byte[] streamBytes = new byte[response.ResponseStream.Length];

			if (response.ResponseStream.CanRead)
			{
				try
				{
					await response.ResponseStream.ReadAsync(streamBytes, 0, Convert.ToInt32(response.ResponseStream.Length));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				response.ResponseStream.Close();
			}

			MemoryStream memoryStream = new MemoryStream(streamBytes);

			return memoryStream;
		}
	}
}