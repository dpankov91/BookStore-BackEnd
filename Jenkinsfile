pipeline {
    agent any
    triggers {
	    cron("0 * * * *")
		pollSCM("*/5 * * * *")
	}
    stages {
        stage("Build Web") {
            steps {
                //echo "===== OPTIONAL: Will build the website (if needed) ====="
                sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.sln"
            }
        }
        stage("Build API") {
            steps {
               // echo "===== REQUIRED: Will build the API project ====="
               sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
            }
        }
        stage("Test API") {
            steps {
                // echo "===== REQUIRED: Will execute unit tests of the API project ====="
               
            }
        }
        stage("Deliver API") {
            steps {
                // echo "===== REQUIRED: Will deliver API to Docker Hub ====="
               
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the Web to Docker Hub ====="
                
            }
        }
        stage("Release staging environment") {
            steps {
                // echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
               
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}