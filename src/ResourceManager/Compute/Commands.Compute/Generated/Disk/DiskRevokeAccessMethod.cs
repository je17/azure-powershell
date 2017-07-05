// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateDiskRevokeAccessDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pDiskName = new RuntimeDefinedParameter();
            pDiskName.Name = "DiskName";
            pDiskName.ParameterType = typeof(string);
            pDiskName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pDiskName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("DiskName", pDiskName);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 3,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteDiskRevokeAccessMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string diskName = (string)ParseParameter(invokeMethodInputParameters[1]);

            var result = DisksClient.RevokeAccess(resourceGroupName, diskName);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateDiskRevokeAccessParameters()
        {
            string resourceGroupName = string.Empty;
            string diskName = string.Empty;

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "DiskName" },
                 new object[] { resourceGroupName, diskName });
        }
    }

    [Cmdlet(VerbsSecurity.Revoke, "AzureRmDiskAccess", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(OperationStatusResponse))]
    public partial class RevokeAzureRmDiskAccess : ComputeAutomationBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.ResourceGroupName, VerbsSecurity.Revoke))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string diskName = this.DiskName;

                    var result = DisksClient.RevokeAccess(resourceGroupName, diskName);
                    WriteObject(result);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Alias("Name")]
        [AllowNull]
        public string DiskName { get; set; }
    }
}
