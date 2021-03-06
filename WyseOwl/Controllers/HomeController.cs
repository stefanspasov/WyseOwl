﻿namespace WyseOwl.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using WyseOwl.Models;
    using System.Web.Mvc;
    using WyseOwl.Logic;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalculationsViewModel1.FirstCalculation
                            {
                                AddressCountry =
                                    this.GetSelectListItems(
                                        this.GetAllAddressCountries()), 
                                WorkCountry = this.GetSelectListItems(this.GetAllWorkCountries()),
                                PerTime = this.GetSelectListItems(this.GetAllPerTime()),
                                Currency = this.GetSelectListItems(this.GetAllCurrencies()),
                                EligibleYear = 2000, 
                                StartYear = 2000,
                                CalculationResult = new CalculationsViewModel1.CalculationResult()
                            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CalculationsViewModel1.FirstCalculation calcultionInputs)
        {
            calcultionInputs.AddressCountry = GetSelectListItems(GetAllAddressCountries());
            calcultionInputs.WorkCountry = GetSelectListItems(GetAllWorkCountries());
            calcultionInputs.PerTime = GetSelectListItems(GetAllPerTime());
            calcultionInputs.Currency = GetSelectListItems(GetAllCurrencies());
            if (!ModelState.IsValid)
            {
                return View("Index", calcultionInputs);
            }


            var client = new NodeCommunication();
            calcultionInputs.CalculationResult  = client.SendFirstCalculation(calcultionInputs);
            return this.Json(new { success = true, result = calcultionInputs.CalculationResult });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Recalculate(CalculationsViewModel1.FirstCalculation calcultionInputs)
        {
            calcultionInputs.AddressCountry = GetSelectListItems(GetAllAddressCountries());
            calcultionInputs.WorkCountry = GetSelectListItems(GetAllWorkCountries());
            calcultionInputs.PerTime = GetSelectListItems(GetAllPerTime());
            calcultionInputs.Currency = GetSelectListItems(GetAllCurrencies());

            var client = new NodeCommunication();
            calcultionInputs.CalculationResult = client.SendSecondCalculation(calcultionInputs);
            return this.Json(new { success = true, result = calcultionInputs.CalculationResult });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactModel contactModel)
        {
            ViewBag.Message = "Your contact page.";

            var body = $"<p>Email From: {contactModel.Name} ({contactModel.Email})</p><p>Message:</p><p>{contactModel.Message}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("stefanspasov90@gmail.com"));  
            message.To.Add(new MailAddress("wyse.owl.partners@gmail.com"));  
            message.From = new MailAddress("stefanspasov90@gmail.com");
            message.Subject = "New message from calculator Contact us";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential { UserName = "stefanspasov90@gmail.com", 
                                                         Password = "pickaboo4" 
                                                       };
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                return View();
            }
        }


        private IEnumerable<string> GetAllAddressCountries()
        {
            return new List<string>
            {
                "England",
                "North Ireland",
                "Wales",
                "Scotland"
            };
        }

        private IEnumerable<string> GetAllWorkCountries()
        {
            return new List<string>
                       {
                           "United Kingdom                                                           ",
                           "Afghanistan                                               ",
                           "Albania                                                                  ",
                           "Algeria                                                                  ",
                           "American Samoa                                                           ",
                           "Andorra                                                                  ",
                           "Angola                                                                   ",
                           "Anguilla                                                                 ",
                           "Antarctica                                                               ",
                           "Antigua and Barbuda                                                      ",
                           "Argentina                                                                ",
                           "Armenia                                                                  ",
                           "Aruba                                                                    ",
                           "Australia                                                                ",
                           "Austria                                                                  ",
                           "Azerbaijan                                                               ",
                           "Bahamas                                                                  ",
                           "Bahrain                                                                  ",
                           "Bangladesh                                                               ",
                           "Barbados                                                                 ",
                           "Belarus                                                                  ",
                           "Belgium                                                                  ",
                           "Belize                                                                   ",
                           "Benin                                                                    ",
                           "Bermuda                                                                  ",
                           "Bhutan                                                                   ",
                           "Bolivia                                                                  ",
                           "Bonaire Saint Eustatius and Saba                                         ",
                           "Bosnia and Herzegovina                                                   ",
                           "Botswana                                                                 ",
                           "Bouvet Island                                                            ",
                           "Brazil                                                                   ",
                           "British Indian Ocean Territory                                           ",
                           "Brunei                                                                   ",
                           "Bulgaria                                                                 ",
                           "Burkina Faso                                                             ",
                           "Burundi                                                                  ",
                           "Cambodia                                                                 ",
                           "Cameroon                                                                 ",
                           "Canada                                                                   ",
                           "Cape Verde                                                               ",
                           "Cayman Islands                                                           ",
                           "Central African Republic                                                 ",
                           "Chad                                                                     ",
                           "Channel Islands                                                          ",
                           "Chile                                                                    ",
                           "China                                                                    ",
                           "Christmas Island                                                         ",
                           "Cocos (Keeling) Islands                                                  ",
                           "Colombia                                                                 ",
                           "Comoros                                                                  ",
                           "Congo                                                                    ",
                           "Congo Democratic Republic of                                             ",
                           "Cook Islands                                                             ",
                           "Costa Rica                                                               ",
                           "Cote d Ivoire                                                            ",
                           "Croatia                                                                  ",
                           "Cuba                                                                     ",
                           "Curacao                                                                  ",
                           "Cyprus                                                                   ",
                           "Czech Republic                                                           ",
                           "Denmark                                                                  ",
                           "Djibouti                                                                 ",
                           "Dominica                                                                 ",
                           "Dominican Republic                                                       ",
                           "Ecuador                                                                  ",
                           "Egypt                                                                    ",
                           "El Salvador                                                              ",
                           "Equatorial Guinea                                                        ",
                           "Eritrea                                                                  ",
                           "Estonia                                                                  ",
                           "Ethiopia                                                                 ",
                           "Faeroe Islands                                                           ",
                           "Falkland Islands                                                         ",
                           "Federated States of Micronesia                                           ",
                           "Fiji                                                                     ",
                           "Finland                                                                  ",
                           "France                                                                   ",
                           "French Guiana                                                            ",
                           "French Polynesia                                                         ",
                           "French Southern Territories                                              ",
                           "Gabon                                                                    ",
                           "Gambia                                                                   ",
                           "Georgia                                                                  ",
                           "Germany                                                                  ",
                           "Ghana                                                                    ",
                           "Gibraltar                                                                ",
                           "Greece                                                                   ",
                           "Greenland                                                                ",
                           "Grenada                                                                  ",
                           "Guadeloupe                                                               ",
                           "Guam                                                                     ",
                           "Guatemala                                                                ",
                           "Guinea                                                                   ",
                           "Guinea-Bissau                                                            ",
                           "Guyana                                                                   ",
                           "Haiti                                                                    ",
                           "Heard and McDonald Islands                                               ",
                           "Holy See (Vatican City State)                                            ",
                           "Honduras                                                                 ",
                           "Hong Kong                                                                ",
                           "Hungary                                                                  ",
                           "Iceland                                                                  ",
                           "India                                                                    ",
                           "Indonesia                                                                ",
                           "Iran                                                                     ",
                           "Iraq                                                                     ",
                           "Ireland                                                                  ",
                           "Isle of Man                                                              ",
                           "Israel                                                                   ",
                           "Italy                                                                    ",
                           "Jamaica                                                                  ",
                           "Japan                                                                    ",
                           "Jordan                                                                   ",
                           "Kazakhstan                                                               ",
                           "Kenya                                                                    ",
                           "Kiribati                                                                 ",
                           "Korea Democratic Peoples Republic of                                     ",
                           "Korea Republic of                                                        ",
                           "Kuwait                                                                   ",
                           "Kyrgyztan Republic                                                       ",
                           "Lao PDR                                                                  ",
                           "Latvia                                                                   ",
                           "Lebanon                                                                  ",
                           "Lesotho                                                                  ",
                           "Liberia                                                                  ",
                           "Libya                                                                    ",
                           "Liechtenstein                                                            ",
                           "Lithuania                                                                ",
                           "Luxembourg                                                               ",
                           "Macau                                                                    ",
                           "Macedonia                                                                ",
                           "Madagascar                                                               ",
                           "Malawi                                                                   ",
                           "Malaysia                                                                 ",
                           "Maldives                                                                 ",
                           "Mali                                                                     ",
                           "Malta                                                                    ",
                           "Marshall Islands                                                         ",
                           "Martinique                                                               ",
                           "Mauritania                                                               ",
                           "Mauritius                                                                ",
                           "Mayotte                                                                  ",
                           "Mexico                                                                   ",
                           "Moldova                                                                  ",
                           "Monaco                                                                   ",
                           "Mongolia                                                                 ",
                           "Montenegro                                                               ",
                           "Montserrat                                                               ",
                           "Morocco                                                                  ",
                           "Mozambique                                                               ",
                           "Myanmar                                                                  ",
                           "Namibia                                                                  ",
                           "Nauru                                                                    ",
                           "Nepal                                                                    ",
                           "Netherlands                                                              ",
                           "New Caledonia                                                            ",
                           "New Zealand                                                              ",
                           "Nicaragua                                                                ",
                           "Niger                                                                    ",
                           "Nigeria                                                                  ",
                           "Niue                                                                     ",
                           "Norfolk Island                                                           ",
                           "Northern Mariana Islands                                                 ",
                           "Norway                                                                   ",
                           "Oman                                                                     ",
                           "Pakistan                                                                 ",
                           "Palau                                                                    ",
                           "Palestine                                                                ",
                           "Panama                                                                   ",
                           "Papua New Guinea                                                         ",
                           "Paraguay                                                                 ",
                           "Peru                                                                     ",
                           "Philippines                                                              ",
                           "Pitcairn                                                                 ",
                           "Poland                                                                   ",
                           "Portugal                                                                 ",
                           "Puerto Rico                                                              ",
                           "Qatar                                                                    ",
                           "Reunion                                                                  ",
                           "Romania                                                                  ",
                           "Russian Federation                                                       ",
                           "Rwanda                                                                   ",
                           "Saint Helena                                                             ",
                           "Saint Kitts and Nevis                                                    ",
                           "Saint Lucia                                                              ",
                           "Saint Martin (French part)                                               ",
                           "Saint Pierre and Miquelon                                                ",
                           "Saint Vincent and Grenadines                                             ",
                           "Saint-Barthelemy                                                         ",
                           "Samoa                                                                    ",
                           "San Marino                                                               ",
                           "Sao Tome and Principe                                                    ",
                           "Saudi Arabia                                                             ",
                           "Senegal                                                                  ",
                           "Serbia                                                                   ",
                           "Seychelles                                                               ",
                           "Sierra Leone                                                             ",
                           "Singapore                                                                ",
                           "Sint Maarten (Dutch part)                                                ",
                           "Slovakia                                                                 ",
                           "Slovenia                                                                 ",
                           "Solomon Islands                                                          ",
                           "Somalia                                                                  ",
                           "South Africa                                                             ",
                           "South Georgia and the South Sandwich Islands                             ",
                           "South Sudan                                                              ",
                           "Spain                                                                    ",
                           "Sri Lanka                                                                ",
                           "Sudan                                                                    ",
                           "Suriname                                                                 ",
                           "Svalbard and Jan Mayen Islands                                           ",
                           "Swaziland                                                                ",
                           "Sweden                                                                   ",
                           "Switzerland                                                              ",
                           "Syria                                                                    ",
                           "Taiwan                                                                   ",
                           "Tajikistan                                                               ",
                           "Thailand                                                                 ",
                           "Timor-Leste                                                              ",
                           "Togo                                                                     ",
                           "Tokelau                                                                  ",
                           "Tonga                                                                    ",
                           "Trinidad and Tobago                                                      ",
                           "Tunisia                                                                  ",
                           "Turkey                                                                   ",
                           "Turkmenistan                                                             ",
                           "Turks and Caicos Islands                                                 ",
                           "Tuvalu                                                                   ",
                           "Uganda                                                                   ",
                           "Ukraine                                                                  ",
                           "United Arab Emirates                                                     ",
                           "United Republic of Tanzania                                              ",
                           "United States of America                                                 ",
                           "Uruguay                                                                  ",
                           "Uzbekistan                                                               ",
                           "Vanuatu                                                                  ",
                           "Venezuela                                                                ",
                           "Vietnam                                                                  ",
                           "Virgin Islands (British)                                                 ",
                           "Virgin Islands (US)                                                      ",
                           "Wallis and Futuna Islands                                                ",
                           "Western Sahara                                                           ",
                           "Yemen                                                                    ",
                           "Zambia                                                                   ",
                           "Zimbabwe                                                                 ",
                       }.Distinct();
        }

        private IEnumerable<string> GetAllPerTime()
        {
            return new List<string>
            {
                "per year", "per month", "per week"
            };
        }

        private IEnumerable<string> GetAllCurrencies()
        {
            return new List<string>
                       {
                           "British Pound                              ",
                           "Afghanis                   ",
                           "Leke                                       ",
                           "Algerian Dinar                             ",
                           "U.S. Dollar                                ",
                           "Euro                                       ",
                           "Kwanza                                     ",
                           "East Caribbean Dollar                      ",
                           "U.S. Dollar                                ",
                           "East Caribbean Dollar                      ",
                           "Argentine Peso                             ",
                           "Dram                                       ",
                           "Aruban Guilder                             ",
                           "Australian Dollar                          ",
                           "Euro                                       ",
                           "Azerbaijanian Manat                        ",
                           "Bahamian Dollar                            ",
                           "Bahrain Dinar                              ",
                           "Taka                                       ",
                           "Barbados Dollar                            ",
                           "Belarusian Ruble                           ",
                           "Euro                                       ",
                           "Belizean Dollar                            ",
                           "CFA Franc (BEAC)                           ",
                           "Bermudian Dollar                           ",
                           "Bhutanese Ngultrum                         ",
                           "Boliviano                                  ",
                           "U.S. Dollar                                ",
                           "Convertible Marka                          ",
                           "Pula                                       ",
                           "Norwegian Krone                            ",
                           "Brazilian Real                             ",
                           "U.S. Dollar                                ",
                           "Brunei Dollar                              ",
                           "Bulgarian Lev                              ",
                           "CFA Franc (BEAC)                           ",
                           "Burundi Franc                              ",
                           "Riel                                       ",
                           "CFA Franc (BEAC)                           ",
                           "Canadian Dollar                            ",
                           "Cape Verde Escudo                          ",
                           "Cayman Islands Dollar                      ",
                           "CFA Franc (BEAC)                           ",
                           "CFA Franc (BEAC)                           ",
                          
                           "Chilean Peso                               ",
                           "Yuan Renminbi                              ",
                           "Australian Dollar                          ",
                           "Australian Dollar                          ",
                           "Colombian Peso                             ",
                           "Comorian Franc                             ",
                           "Congolese Franc                            ",
                           "Congolese Franc                            ",
                           "New Zealand Dollar                         ",
                           "Costa Rican Colon                          ",
                           "CFA Franc (BEAC)                           ",
                           "Kuna                                       ",
                           "Cuban Peso                                 ",
                           "Antillean Guilder                          ",
                           "Euro                                       ",
                           "Czech Koruna                               ",
                           "Danish Krone                               ",
                           "Djiboutian Franc                           ",
                           "East Caribbean Dollar                      ",
                           "Dominican Peso                             ",
                           "U.S. Dollar                                ",
                           "Egyptian Pound                             ",
                           "U.S. Dollar                                ",
                           "CFA Franc (BEAC)                           ",
                           "Nafka                                      ",
                           "Euro                                       ",
                           "Ethiopian Birr                             ",
                           "Danish Krone                               ",
                           "Falkland Pound                             ",
                           "U.S. Dollar                                ",
                           "Fiji Dollar                                ",
                           "Euro                                       ",
                           "Euro                                       ",
                           "Euro                                       ",
                           "CFP Franc                                  ",
                           "Euro                                       ",
                           "CFA Franc (BEAC)                           ",
                           "Dalasi                                     ",
                           "Lari                                       ",
                           "Euro                                       ",
                           "Ghanaian Cedi                              ",
                           "British Pound                              ",
                           "Euro                                       ",
                           "Danish Krone                               ",
                           "East Caribbean Dollar                      ",
                           "Euro                                       ",
                           "U.S. Dollar                                ",
                           "Quetzal                                    ",
                           "Guinean Franc                              ",
                           "CFA Franc (BCEAO)                          ",
                           "Guyanese Dollar                            ",
                           "Gourde                                     ",
                           "Australian Dollar                          ",
                           "Euro                                       ",
                           "Lempira                                    ",
                           "Hong Kong Dollar                           ",
                           "Forint                                     ",
                           "Icelandic Krona                            ",
                           "Indian Rupee                               ",
                           "Indonesian Rupiah                          ",
                           "Iranian Rial                               ",
                           "Iraqi Dinar                                ",
                           "Euro                                       ",
                           "British Pound                              ",
                           "New Israeli Shekel                         ",
                           "Euro                                       ",
                           "Jamaican Dollar                            ",
                           "Yen                                        ",
                           "Jordanian Dinar                            ",
                           "Tenge                                      ",
                           "Kenya Schilling                            ",
                           "Australian Dollar                          ",
                           "Won Korea Dem. Rep                         ",
                           "Won Korea Rep                              ",
                           "Kuwaiti Dinar                              ",
                           "Kyrgyzstan Som                             ",
                           "Kip                                        ",
                           "Euro                                       ",
                           "Lebanese Pound                             ",
                           "Loti                                       ",
                           "Liberian Dollar (US Dollar in use)         ",
                           "Libyan Dinar                               ",
                           "Swiss Franc                                ",
                           "Euro                                       ",
                           "Euro                                       ",
                           "Patacas                                    ",
                           "Macedonian Denar                           ",
                           "Malagasy Ariary                            ",
                           "Malawi Kwacha                              ",
                           "Ringgit                                    ",
                           "Rufiyaa                                    ",
                           "CFA Franc (BCEAO)                          ",
                           "Euro                                       ",
                           "U.S. Dollar                                ",
                           "Euro                                       ",
                           "Ouguiyas                                   ",
                           "Mauritius Rupee                            ",
                           "Euro                                       ",
                           "Mexican Peso                               ",
                           "Moldovan Leu                               ",
                           "Euro                                       ",
                           "Tugrik                                     ",
                           "Euro                                       ",
                           "East Caribbean Dollar                      ",
                           "Moroccan Dirham                            ",
                           "Metical                                    ",
                           "Kyat                                       ",
                           "Namibian Dollar                            ",
                           "Australian Dollar                          ",
                           "Nepalese Rupee                             ",
                           "Euro                                       ",
                           "CFP Franc                                  ",
                           "New Zealand Dollar                         ",
                           "Gold Cordoba                               ",
                           "CFA Franc (BCEAO)                          ",
                           "Nigerian Naira                             ",
                           "New Zealand Dollar                         ",
                           "Australian Dollar                          ",
                           "U.S. Dollar                                ",
                           "Norwegian Krone                            ",
                           "Rial Omani                                 ",
                           "Pakistan Rupee                             ",
                           "U.S. Dollar                                ",
                           "New Israeli Shekel                         ",
                           "Balboas                                    ",
                           "Kina                                       ",
                           "Guarani                                    ",
                           "New Sol                                    ",
                           "Philippine Peso                            ",
                           "New Zealand Dollar                         ",
                           "Zloty                                      ",
                           "Euro                                       ",
                           "U.S. Dollar                                ",
                           "Qatar Riyal                                ",
                           "Euro                                       ",
                           "Romanian Leu                               ",
                           "Russian Ruble                              ",
                           "Rwanda Franc                               ",
                           "Saint Helena Pound                         ",
                           "East Caribbean Dollar                      ",
                           "East Caribbean Dollar                      ",
                           "Euro                                       ",
                           "Euro                                       ",
                           "East Caribbean Dollar                      ",
                           "Euro                                       ",
                           "Tala                                       ",
                           "Euro                                       ",
                           "Dobras                                     ",
                           "Saudi Riyal                                ",
                           "CFA Franc (BEAC)                           ",
                           "Serbian Dinar                              ",
                           "Seychelles Rupee                           ",
                           "Leone                                      ",
                           "Singapore Dollar                           ",
                           "Antilles Guilder                           ",
                           "Euro                                       ",
                           "Euro                                       ",
                           "Solomon Islands Dollar                     ",
                           "Somali Shilling                            ",
                           "Rand                                       ",
                           "British Pound                              ",
                           "Sudanese Pound                             ",
                           "Euro                                       ",
                           "Sri Lankan Rupee                           ",
                           "Sudanese Pound                             ",
                           "Surinam Dollar                             ",
                           "Norwegian Krone                            ",
                           "Lilangeni                                  ",
                           "Swedish Krona                              ",
                           "Swiss Franc                                ",
                           "Syrian Pound                               ",
                           "Taiwan Dollar                              ",
                           "Somoni                                     ",
                           "Thai Baht                                  ",
                           "U.S. Dollar                                ",
                           "CFA Franc (BEAC)                           ",
                           "New Zealand Dollar                         ",
                           "Pa’anga                                    ",
                           "Trinidad & Tobago Dollar                   ",
                           "Tunisian Dinar                             ",
                           "Turkish New Lira                           ",
                           "Turkmenistan New Manat                     ",
                           "U.S. Dollar                                ",
                           "Australian Dollar                          ",
                           "Ugandan New Shilling                       ",
                           "Hryvnia                                    ",
                           "U.A.E. Dirham                              ",
                           "British Pound                              ",
                           "Tanzanian Shilling                         ",
                           "U.S. Dollar                                ",
                           "Uruguayan Peso                             ",
                           "Uzbekistan Sum                             ",
                           "Vatu                                       ",
                           "Bolivar Fuerte                             ",
                           "Dong                                       ",
                           "U.S. Dollar                                ",
                           "U.S. Dollar                                ",
                           "CFP Franc                                  ",
                           "Moroccan Dirham                            ",
                           "Yemeni Rial                                ",
                           "Zambian Kwacha                             ",
                           "Zimbabwean Dollar                          ",
                       }.Distinct();
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>

            return elements.Select(element => new SelectListItem { Value = element.Trim(), Text = element.Trim() }).ToList();
        }
    }
}