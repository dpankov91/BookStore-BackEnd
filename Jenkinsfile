pipeline{
	agent any
		triggers {
		 cron("0 * * * *")
}
stages {
	stage("Build Web") {
	  steps {
	    sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
		}
	}
	stage("Build API") {
            steps {
               // echo "===== REQUIRED: Will build the API project ====="
               sh "dotnet build BookStore-BackEnd/BookStore-BackEnd/BookStore-BackEnd.csproj"
            }
        }
}
}
	