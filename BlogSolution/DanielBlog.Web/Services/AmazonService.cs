using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class AmazonService
    {
        private string AWSAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
        private string AWSSecret = ConfigurationManager.AppSettings["AWSSecret"];
        private string AWSBucketName = ConfigurationManager.AppSettings["AWSBucketName"];

        public string UploadFile(Stream fileStream, string fileName)
        {
            try
            {
                var g = Guid.NewGuid();
                string fileNameAtAws = g.ToString() + "_" + fileName.Replace("+", "0");
                AWSCredentials awsCredentials = new BasicAWSCredentials(AWSAccessKey, AWSSecret);
                AmazonS3Client client = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.USWest1);
                TransferUtility fileTransferUtility = new TransferUtility(client);
                TransferUtilityUploadRequest uploadRequest = new TransferUtilityUploadRequest();
                uploadRequest.BucketName = AWSBucketName;
                uploadRequest.InputStream = fileStream;
                uploadRequest.Key = fileNameAtAws;
                // send file to Amazon
                fileTransferUtility.Upload(uploadRequest);
                return fileNameAtAws;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKey")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}