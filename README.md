## Simple example for calling API of Kofax TotalAgility
#### API documentation
KTA 7.10 https://docshield.kofax.com/KTA/en_US/7.10.0-vmhad0mru4/help/SDK_Documentation/latest/index.html <br>
More versions in https://github.com/infomatic-cz/KofaxTotalAgility
#### Call using WSDL
- Service client is generated by adding service wsdl as Connected services in Visual Studio
- Commented code is in [Class1.cs](KTA_REST_API_Example/Class1.cs)
#### Call using WebRequest
- REST call using WebRequest is in [RestCall.cs](KTA_REST_API_Example/RestCall.cs)
- My code above is also used by Kofax in knowledge base article https://knowledge.kofax.com/Smart_Process_Applications_-_TotalAgility/New_Articles/Passing_value_to_a_dynamic_complex_variable_using_JSON_string
