var inputNum = document.getElementById("input");
var textAns = document.getElementById("ans")
var submit = document.getElementById("submit")


submit.addEventListener("click", function() {
    console.log(inputNum.value)
    userNum = inputNum.value
    textAns.textContent = `Fibonacci at ${inputNum.value} is "${fibonacci(userNum)}"    `
})

function fibonacci(num) {
    if (num == 0) {
        return 1
    } else if (num == 1) {
        return 0
    } else if (num == 2) {
        return 1
    } else {
        return fibonacci(num - 1) + fibonacci(num - 2);
    }
}