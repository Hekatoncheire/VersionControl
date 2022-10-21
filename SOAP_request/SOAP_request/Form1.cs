using SOAP_request.Entities;
using SOAP_request.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace SOAP_request
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        string XMLResultRates;
        string XMLResultCurrencies;
        public Form1()
        {
            InitializeComponent();
            GetMnbCurrencies();
            RefreshData();
        }

        private void GetMnbCurrencies()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetCurrenciesRequestBody();

            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;

            XMLResultCurrencies = result;
            CreateXMLCurrencies(result);
        }

        private void CreateXMLCurrencies(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement.ChildNodes[0])
            {
                string currency;
                var childElement = element.ChildNodes[0];
                if (childElement == null)
                    continue;
                currency = childElement.InnerText;
                Currencies.Add(currency);
            }
        }

        private void RefreshData()
        {
            Rates.Clear();
            currencyBox.DataSource = Currencies;
            MnbSoapRequest();
            dataGridView1.DataSource = Rates;
            CreateXMLRates(XMLResultRates);
            CreateChart();
        }

        private void CreateChart()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void CreateXMLRates(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null)
                    continue;
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        private void MnbSoapRequest()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = currencyBox.SelectedItem.ToString(),
                startDate = startDatePicker.Value.ToString(),
                endDate = endDatePicker.Value.ToString()
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            XMLResultRates = result;
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void currencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
