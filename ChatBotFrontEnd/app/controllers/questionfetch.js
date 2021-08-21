app.controller("questionanswer",function($scope,ajax){
    ajax.get("https://localhost:44302/api/Question/3/",function(response){
        $scope.students = response.data;
    },function(error){

    });
});
