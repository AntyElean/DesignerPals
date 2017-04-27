namespace DesignerPals.Controllers {

    export class HomeController {
        private qResource
        public allQuestions;
        public question;

        public getQuestion()
        {
            this.allQuestions = this.qResource.query();
        }
        public save()
        {
            this.qResource.save(this.question).$promise.then(
                () => {
                this.question = null;
                this.getQuestion();
                }
                )
        }
        constructor(private $http: ng.IHttpService)
        {
            this.qResource = $http.get('/api/questions/:id').then(
                (results) => { this.question = results.data; }
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
