namespace DesignerPals.Controllers {

    export class HomeController {
        
        public question;
        
        constructor(private $http: ng.IHttpService)
        {
           $http.get('/api/questions/:id').then(
               (results) => {
                   this.question = results.data;
               }
            );
        }
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {

    }

}
