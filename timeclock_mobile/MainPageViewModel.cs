using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeclock_mobile
{
    class MainPageViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public MainPageViewModel()
        {

        }

        public IEnumerable<object> Data { get; private set; }

        private async Task FetchData()
        {
            var creds = new Amazon.CognitoIdentity.CognitoAWSCredentials("us-east-2:cae5748b-070e-4cf0-85a9-f3173c086478", Amazon.RegionEndpoint.USEast2);

            var ddbClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient(creds, Amazon.RegionEndpoint.USEast2);

            var results = await ddbClient.ScanAsync(new ScanRequest
            {
                TableName = "TimeCards",
                AttributesToGet = new List<string> { "employeeID", "firstName", "lastName", "email" }
            });

            Data = results.Items.Select(i => new
            {
                id = i["employeeID"].S,
                firstName = i["firstName"].S,
                lastName = i["lastName"].S,
                email = i["email"].S
            }).OrderBy(i => i.id);

            RaisePropertyChanged(nameof(Data));
        }
    }
}
