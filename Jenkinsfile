pipeline {
    agent any
    stages {
        stage("Pull frontend repository") {
            steps {
                sh "rm -r BookStore-FrontEnd"
                sh "git clone https://github.com/dpankov91/BookStore-FrontEnd BookStore-FrontEnd"
            }
        }
        stage("Build Web") {
            steps {
				echo "build web"
            }
        }
        stage("Build API") {
            steps {
				sh "dotnet build BookStore-BackEnd/BookStore-BackEnd.csproj"
            }
        }
        stage("Test API") {
            steps {
		        sh "dotnet test XUnitTest/XUnitTest.csproj"
            }
        }
        stage("Deliver API") {     
            steps {
                sh "docker build . -t dpankov91/bookstore"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }            
                sh "docker push dpankov91/bookstore"
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
