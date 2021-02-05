pipeline{
	agent any
		trigger {
		 cron("* * * * *")
}
stages {
	stage("Build") {
	  steps {
	    sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
		}
	}
}
}
	