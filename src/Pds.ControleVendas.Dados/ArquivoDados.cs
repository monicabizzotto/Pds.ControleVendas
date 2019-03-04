using Amazon;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using System;
using System.IO;
using System.Text;

namespace Pds.ControleVendas.Dados
{
	public class ArquivoDados
	{
		public ArquivoDados(IAmazonS3 s3Client)
		{
			var options = new CredentialProfileOptions
			{
				AccessKey = "AKIAJQJV7TW2I5HDQDYQ",
				SecretKey = "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"
			};
			var profile = new Amazon.Runtime.CredentialManagement.CredentialProfile("basic_profile", options);
			profile.Region = RegionEndpoint.USEast1;
			var netSDKFile = new NetSDKCredentialsFile();
			netSDKFile.RegisterProfile(profile);
			
		}
	}
}