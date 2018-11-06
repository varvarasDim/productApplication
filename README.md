Three projects are included

	- FrontEndApplication 
	- IntegrationTests
	- Product


- FrontEndApplication is a Vue.js application that shows the products
	In order to run it you need to have the Product project running given that it is the backend of the application.
	Then execute from the folder of the application:
	- npm install
	- npm run dev

- Product is the Product backend service that feeds with data
	In order to execute it just click F5 from visual studio.
	UnitTests have been added to the project to protect the functionality.
	Swagger has been added to the project for developer convenience.
	
- IntegrationTests
	In order to run the Integration tests you need to have the backend running and then from the tests viewer of visual studio you can execute the tests.
	The tests are running against the same machine where the backend runs. The port is preinjected through the app.config file.
	

