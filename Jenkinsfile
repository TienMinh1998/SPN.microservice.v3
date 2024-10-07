   pipeline{
    agent any
    stages{
        stage("Clone github"){
            steps{
                 git 'https://github.com/TienMinh1998/SPN.microservice.v3.git'
            }
        }
         stage("build Server"){
            steps{
                 echo 'Start build'
                 bat 'dotnet --version'
                 bat 'dotnet build'
                 bat 'docker stop demo'
                 bat 'docker rm -f demo'
                 bat 'docker rmi jenkinsdemo'
                 bat 'docker build -t jenkinsdemo .'
                 bat 'docker run -it -d -p 8181:80 --name demo -e ASPNETCORE_ENVIRONMENT=Development jenkinsdemo'
                 echo 'MT007'
                 echo 'Nguyen Viet Minh Tien 1'
            }
        }
         stage("devploy"){
            steps{
                 bat 'docker ps'
                 bat 'docker images'
                 bat 'docker ps -a'
            }
        }
    }
}