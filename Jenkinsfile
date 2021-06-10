pipeline {
    agent any
    triggers {
		cron("0 * * * *")
        pollSCM("* * * * *")
	}
    stages {
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
                sh "docker-compose pull"
                sh "docker-compose up -d --build"
            }
        }
    }
}
