// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Kudvenkat (2019) ASP NET Core delete confirmation. Available at: https:
// www.youtube.com/watch?v=hKLjt9GzYM8&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=87&ab_channel=kudvenkat 


// Available at: 
// https://www.c-sharpcorner.com/blogs/hide-and-show-div-using-javascript1

// 
// function ShowHideTable()
// {
//         var div = document.getElementById("ComparisonTable");
//         if (div.style.display !== "none")
//         {
//             div.style.display = "none";
//         }
//         else
//         {
//             div.style.display = "block";
//         }
// }

function ShowHidePlayerStats(playerId) {
    var statsRow = document.getElementById("playerStats_" + playerId);
    if (statsRow.style.display === "none") {
        statsRow.style.display = "table-row";
    } else {
        statsRow.style.display = "none";
    }
}
// function ProductAdded(addToCartIsClicked){
//     var addToCart = 'AddToCart';
//     var productAdded = 'ProductAdded';
//      if(addToCartIsClicked){
//          $().show();
//      }
// }
