   pipeline{
    agent any
    stages{
        stage("Clone github"){
            steps{
                 git 'https://github.com/TienMinh1998/SPN.microservice.v3.git'
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