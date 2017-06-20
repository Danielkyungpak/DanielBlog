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
                //get unique Id GUID
                var g = Guid.NewGuid();
                //create the path...where pic is stored and how to get it later
                string fileNameAtAws = g.ToString() + "_" + fileName.Replace("+", "0");
                //create local variable to store credentials
                AWSCredentials awsCredentials = new BasicAWSCredentials(AWSAccessKey, AWSSecret);
                //create a new client with the keys we have-- to access Amazon AWS
                AmazonS3Client client = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.USWest1);
                //create transfer utility and pass client in as a parameter
                TransferUtility fileTransferUtility = new TransferUtility(client);
                //make request in a way that Amazon can read what we are sending (upload Request)
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