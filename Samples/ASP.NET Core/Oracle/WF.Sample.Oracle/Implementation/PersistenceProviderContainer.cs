﻿using Microsoft.Extensions.Configuration;
using OptimaJet.Workflow.Core.Generator;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Oracle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WF.Sample.Business.DataAccess;

namespace WF.Sample.Oracle.Implementation
{
    public class PersistenceProviderContainer : IPersistenceProviderContainer
    {
        public PersistenceProviderContainer(IConfiguration config)
        {
            _provider = new OracleProvider(config.GetConnectionString("DefaultConnection"));
        }

        private readonly OracleProvider _provider;

        public IPersistenceProvider AsPersistenceProvider => _provider;

        public ISchemePersistenceProvider<XElement> AsSchemePersistenceProvider => _provider;

        public IWorkflowGenerator<XElement> AsWorkflowGenerator => _provider;
    }
}
