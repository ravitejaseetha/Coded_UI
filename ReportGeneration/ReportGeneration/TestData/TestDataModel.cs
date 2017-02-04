using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReportGeneration
{
    
        public class LoginData
        {
            [XmlElement("UserMail")]
            public string UserMail { get; set; }
            [XmlElement("UserID")]
            public string UserID { get; set; }
            [XmlElement("Password")]
            public string Password { get; set; }
        }
        public class CreateProjectData
        {
            [XmlElement("AccountName")]
            public string AccountName { get; set; }
            [XmlElement("AccountNameTwo")]
            public string AccountNameTwo { get; set; }
            [XmlElement("CalculatorType")]
            public string CalculatorType { get; set; }
            [XmlElement("ProjectName")]
            public string ProjectName { get; set; }

            [XmlElement("CurrencyType")]
            public string CurrencyType { get; set; }
        }
    [XmlRoot("CreateProjectData")]
    public class Data
    {

        public Data()
        {
            CreateOpportunity = new List<CreateProjectData>();
        }

        [XmlElement("Data")]
        public List<CreateProjectData> CreateOpportunity { get; set; }

    }

    public class ParametersData
    {
        [XmlElement("DeltaTemperatureUS")]
        public string DeltaTemperatureUS { get; set; }
        [XmlElement("RecirculationRateUS")]
        public string RecirculationRateUS { get; set; }

        [XmlElement("DriftFactorUS")]
        public string DriftFactorUS { get; set; }
        [XmlElement("EvaporationFactorUS")]
        public string EvaporationFactorUS { get; set; }

        [XmlElement("DeltaTemperatureMetric")]
        public string DeltaTemperatureMetric { get; set; }
        [XmlElement("RecirculationRateMetricPerDay")]
        public string RecirculationRateMetricPerDay { get; set; }

        [XmlElement("DriftFactorMetric")]
        public string DriftFactorMetric { get; set; }
        [XmlElement("EvaporationFactorMetric")]
        public string EvaporationFactorMetric { get; set; }

        [XmlElement("MakeupWaterCost")]
        public string MakeupWaterCost { get; set; }

        [XmlElement("OperatingDaysPerYear")]
        public string OperatingDaysPerYear { get; set; }
        [XmlElement("CyclesOfConcentration")]
        public string CyclesOfConcentration { get; set; }
        [XmlElement("CyclesOfConcentration_Proposed")]
        public string CyclesOfConcentrationProposed { get; set; }

        [XmlElement("ChemicalTreatmentCost")]
        public string ChemicalTreatmentCost { get; set; }
        [XmlElement("LaborCost")]
        public string LaborCost { get; set; }
        [XmlElement("MaintenanceCost")]
        public string MaintenanceCost { get; set; }

        [XmlElement("ProductionCost")]
        public string ProductionCost { get; set; }
        [XmlElement("MiscellaneousCost")]
        public string MiscellaneousCost { get; set; }
        [XmlElement("ChemicalTreatmentCost_Proposed")]
        public string ChemicalTreatmentCost_Proposed { get; set; }

        [XmlElement("LaborCost_Proposed")]
        public string LaborCost_Proposed { get; set; }
        [XmlElement("MaintenanceCost_Proposed")]
        public string MaintenanceCost_Proposed { get; set; }

        [XmlElement("ProductionCost_Proposed")]
        public string ProductionCost_Proposed { get; set; }
        [XmlElement("MiscellaneousCost_Proposed")]
        public string MiscellaneousCost_Proposed { get; set; }

    }

}
