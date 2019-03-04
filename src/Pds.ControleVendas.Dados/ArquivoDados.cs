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
		IAmazonS3 s3Client;
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

			var gor = s3Client.GetObjectAsync(new Amazon.S3.Model.GetObjectRequest() { BucketName = "controlevendas", Key = arquivos[109] });

			Task.WaitAll(gor);

			GetObjectResponse getObjectResponse = gor.Result;
			StreamReader reader = new StreamReader(getObjectResponse.ResponseStream);

			var arquivo = reader.ReadToEnd();
			reader.Close();

			return arquivos;
		}
	}
}