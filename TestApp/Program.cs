using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
	            'resourceType': 'Bundle',
	            'id': 'fe17f0388f0007438fb81d3bb7e5d122',
	            'meta': {
		            'lastUpdated': '2019-11-28T11:08:29.650993+00:00'
	            },
	            'type': 'searchset',
	            'link': [{
		            'relation': 'next',
		            'url': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient?ct=eyJ0b2tlbiI6IitSSUQ6fnBVRllBUDdPQm5ObEJRQUFBQUFBQUE9PSNSVDoxI1RSQzoxMCNJU1Y6MiNJRU86NjU1MzYjRlBDOkFnRUFBZ0F5QUdXRnZZQ3JnTU9BSjRGUGdBZUE4WUNsZ0JLQXM0R1lnTUtBdTRDNmdNS0E3WUR1Z0Fxa2U0QlJnTnVEUDRGSGdjYUFBVFFBaUpYOGdUQ0NFSURzZ0ZpQWVJR2ZnRVdGTFlFS2dDcUM0WUd4Z1dlQi80RGhBeEFRWDRBRWdTaUJuWUp5Z1VFQ1FBZ2hnUUlXQUVXQTVZQTVnSCtKSVlISGdRYURDb0JZZ0RFQUFJUT0iLCJyYW5nZSI6eyJtaW4iOiIiLCJtYXgiOiJGRiJ9fQ%3D%3D'
	            }, {
		            'relation': 'self',
		            'url': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient'
	            }],
	            'entry': [{
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/af47b8b6-d2a9-424f-ac8a-32c3c1175469',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'af47b8b6-d2a9-424f-ac8a-32c3c1175469',
			            'meta': {
				            'versionId': '1',
				            'lastUpdated': '2019-03-11T15:36:05.6795458+00:00'
			            },
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Kirk',
				            'given': ['James', 'Tiberious']
			            }, {
				            'use': 'usual',
				            'given': ['Jim']
			            }],
			            'gender': 'male',
			            'birthDate': '1960-12-25'
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-1098667',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-1098667',
			            'meta': {
				            'versionId': '6',
				            'lastUpdated': '2019-03-15T16:35:57.7314778+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Robert Hill</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-1098667'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Hill',
				            'given': ['Robert', 'P']
			            }],
			            'telecom': [{
				            'system': 'email',
				            'value': 'robert.hill@example.com'
			            }],
			            'gender': 'male',
			            'birthDate': '1953-10-27',
			            'address': [{
				            'use': 'home',
				            'line': ['42 Park St'],
				            'city': 'Bixby',
				            'state': 'OK',
				            'postalCode': '74008',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71081332'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-7777703',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-7777703',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:47:02.8882967+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Paul Luttrell</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-7777703'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Luttrell',
				            'given': ['Paul']
			            }],
			            'gender': 'male',
			            'birthDate': '2003-08-01',
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71482713'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-5555002',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-5555002',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:43:58.914497+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Michael Peters</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-5555002'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Peters',
				            'given': ['Michael', 'J']
			            }],
			            'telecom': [{
				            'system': 'email',
				            'value': 'michael.peters@example.com'
			            }],
			            'gender': 'male',
			            'birthDate': '1967-01-02',
			            'address': [{
				            'use': 'home',
				            'line': ['277 Dan Road'],
				            'city': 'Greensboro',
				            'state': 'NC',
				            'postalCode': '27214',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-72080416'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-1186747',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-1186747',
			            'meta': {
				            'versionId': '5',
				            'lastUpdated': '2019-03-15T16:36:15.7578784+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Daniel Johnson</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-1186747'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Johnson',
				            'given': ['Daniel', 'A']
			            }],
			            'telecom': [{
				            'system': 'phone',
				            'value': '800-504-6466',
				            'use': 'mobile'
			            }, {
				            'system': 'email',
				            'value': 'daniel.johnson@example.com'
			            }],
			            'gender': 'male',
			            'birthDate': '1995-02-22',
			            'address': [{
				            'use': 'home',
				            'line': ['2 Main Ave'],
				            'city': 'Broken Arrow',
				            'state': 'OK',
				            'postalCode': '74014',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71032702'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-8888801',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-8888801',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:47:23.0396087+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Philip Jones</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-8888801'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Jones',
				            'given': ['Philip']
			            }],
			            'gender': 'male',
			            'birthDate': '1953-03-17',
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71614502'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-880378',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-880378',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:47:11.5607107+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Amy Lee</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-880378'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Lee',
				            'given': ['Amy', 'R']
			            }],
			            'telecom': [{
				            'system': 'email',
				            'value': 'amy.lee@example.com'
			            }],
			            'gender': 'female',
			            'birthDate': '1999-12-08',
			            'address': [{
				            'use': 'home',
				            'line': ['35 Ridge St'],
				            'city': 'Tulsa',
				            'state': 'OK',
				            'postalCode': '74117',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-72080416'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-8888802',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-8888802',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:47:42.797931+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Tiffany Westin</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-8888802'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Westin',
				            'given': ['Tiffany']
			            }],
			            'gender': 'female',
			            'birthDate': '1975-05-20',
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71614502'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-1869612',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-1869612',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:40:58.3310142+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Anthony Coleman</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-1869612'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Coleman',
				            'given': ['Anthony', 'Z']
			            }],
			            'telecom': [{
				            'system': 'phone',
				            'value': '800-176-9648',
				            'use': 'mobile'
			            }, {
				            'system': 'email',
				            'value': 'anthony.coleman@example.com'
			            }],
			            'gender': 'male',
			            'birthDate': '1950-07-31',
			            'address': [{
				            'use': 'home',
				            'line': ['2 Main Rd'],
				            'city': 'Bixby',
				            'state': 'OK',
				            'postalCode': '74008',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-71614502'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }, {
		            'fullUrl': 'https://aridhia-hdruk-synth.azurehealthcareapis.com/Patient/smart-2081539',
		            'resource': {
			            'resourceType': 'Patient',
			            'id': 'smart-2081539',
			            'meta': {
				            'versionId': '4',
				            'lastUpdated': '2019-03-15T16:42:01.0072414+00:00'
			            },
			            'text': {
				            'status': 'generated',
				            'div': '<div xmlns=\'http://www.w3.org/1999/xhtml\'>Michelle Wilson</div>'
			            },
			            'identifier': [{
				            'use': 'official',
				            'type': {
					            'coding': [{
						            'system': 'http://hl7.org/fhir/v2/0203',
						            'code': 'MR',
						            'display': 'Medical Record Number'
					            }],
					            'text': 'Medical Record Number'
				            },
				            'system': 'http://hospital.smarthealthit.org',
				            'value': 'smart-2081539'
			            }],
			            'active': true,
			            'name': [{
				            'use': 'official',
				            'family': 'Wilson',
				            'given': ['Michelle', 'T']
			            }],
			            'telecom': [{
				            'system': 'phone',
				            'value': '800-853-8117',
				            'use': 'home'
			            }, {
				            'system': 'email',
				            'value': 'michelle.wilson@example.com'
			            }],
			            'gender': 'female',
			            'birthDate': '1927-12-11',
			            'address': [{
				            'use': 'home',
				            'line': ['65 Ridge St'],
				            'city': 'Sapulpa',
				            'state': 'OK',
				            'postalCode': '74066',
				            'country': 'USA'
			            }],
			            'generalPractitioner': [{
				            'reference': 'Practitioner/smart-Practitioner-7880378'
			            }]
		            },
		            'search': {
			            'mode': 'match'
		            }
	            }]
            }";

            Patient.getHospitalNumberDateOfBirth(json);

            StreamReader stream = new StreamReader(Current.Server.MapPath("~/Data/users.json"));
            //string file = stream.ReadToEnd();
            //List<string> items = JsonConvert.DeserializeObject<List<string>>(json);


            //foreach(var item in items)
            //{
            //    Console.Write(item);
            //}

            string path = Path.GetFullPath("users.json");

            Console.WriteLine(path);

            Console.ReadLine();
        }
    }
}
