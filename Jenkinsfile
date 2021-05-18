pipeline {
    agent any
    stages {
        stage("Build Web") {
            steps {
                echo "===== OPTIONAL: Will build the website (if needed) ====="
				sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.sln"
            }
        }
        stage("Build API") {
            steps {
                echo "===== REQUIRED: Will build the API project ====="
				sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach) ====="
            }
        }
        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
		sh "dotnet test test/UnitTest UnitTest.csproj"
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
		sh "docker build src/. -t dpankov91/?1 -f ?2/Dockerfile"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push dpankov91/?1"
            }
        }
        stage("Deliver API") {     
            steps {
                // echo "===== REQUIRED: Will deliver API to Docker Hub ====="
                sh "docker build src/. -t dpankov91/?1 -f ?2/Dockerfile"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }   
                sh "docker push dpankov91/?1"
      
        }
	stage("Deliver Web and Api") {
        	steps {
			parallel(
				deliverWeb: {
					sh "docker build ./src/?? -t ??"
					sh "docker push ??"
				},
				deliverApi: {
					sh "docker build ./src/?? -t ??"
					sh "docker push ??"
				}
			)
            }
        }	
        stage("Release staging environment") {
            steps {
                echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
		sh "docker-compose pull"
                sh "docker-compose up -d --build"
		sh "docker-compose up flyway"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
}