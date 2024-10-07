pipeline {
    agent any
    stages {
        stage("Clone GitHub") {
            steps {
                git 'https://github.com/TienMinh1998/SPN.microservice.v3.git'
            }
        }
        stage("Deploy") {
            steps {
                script {
                    bat 'docker ps'
                    bat 'docker images'
                    bat 'docker ps -a'
                }
            }
        }
    }
}