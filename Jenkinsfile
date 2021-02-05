pipeline{
	agent any
		trigger{
		 cron("0 * * * *")
}
stages {
	stage("Build"){
	  steps{
	    sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
		}
	}
}
	