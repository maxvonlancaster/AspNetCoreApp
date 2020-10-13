export default class Fundamentals {
    //JS:
    //Difference between var, let, const
    Difference() {
        // var declarations are globally scoped or function/locally scoped.
        // The scope is global when a var variable is declared outside a function.This means that any 
        // variable that is declared with var outside a function block is available for use in the whole window.
        // var variables can be re-declared and updated
        var greeter = "hey hi";
        var times = 4;
        if (times > 3) {
            var greeter = "say Hello instead";
        }
        console.log(greeter) // "say Hello instead" -- problem with var 
        // If you have used greeter in other parts of your code, you might be surprised at the output you might get.

        // let is block scoped. A block is a chunk of code bounded by { }.A block lives in curly braces.
        // Anything within curly braces is a block.
        let greeting = "say Hi";
        let times = 4;
        if (times > 3) {
            let hello = "say Hello instead";
            console.log(hello);// "say Hello instead"
        }
        console.log(hello) // hello is not defined
        // ust like  var, let declarations are hoisted to the top. Unlike var which is initialized as undefined, 
        // the let keyword is not initialized.So if you try to use a let variable before declaration, you'll get a Reference Error.

        // Variables declared with the const maintain constant values. const declarations share some similarities with let declarations. 
        // Const is block scoped, const cannot be updated or re-declared
        const hi = "say Hi";
        hi = "say Hello instead";// error: Assignment to constant variable. 
    }

    //How hoisting works
    Hoisting() {
        // In JavaScript, a variable can be declared after it has been used. In other words; a variable can be 
        // used before it has been declared.

        // Hoisting is JavaScript's default behavior of moving all declarations to the top of the current scope
        x = 5; // Assign 5 to x
        elem = document.getElementById("demo"); // Find an element
        elem.innerHTML = x;                     // Display x in the element
        var x; // Declare x

        // Variables defined with let and const are hoisted to the top of the block, but not initialized.
        // Meaning: The block of code is aware of the variable, but it cannot be used until it has been declared.
    }

    //Benefit of Immediately Invoked Function Expression
    ImmeiatelyInvokedFunct() {
        // Sometimes you need to define and call function at the same time and only once so in this case anonymous 
        // function helps you.In such situations giving functions a name and then calling them is just excess.
    }

    //Array method.reduce() how works
    ArrayReduce() {
        // The reduce() method reduces the array to a single value.
        // The reduce() method executes a provided function for each value of the array(from left - to - right).
        // The return value of the function is stored in an accumulator(result / total).
        // Note: reduce() does not execute the function for array elements without values.
        // Note: this method does not change the original array.

        var numbers = [175, 50, 25];
        console.log(numbers.reduce(myFunc)); // 100
        function myFunc(total, num) {
            return total - num;
        }
    }

    //Arrow function vs function
    ArrowFunVSFunc() {
        let add = (x, y) => x + y;
        // Arrow functions do not have an arguments binding. However, they have access to the arguments object of the 
        // closest non - arrow parent function.

        // Unlike regular functions, arrow functions do not have their own this. The value of this inside an arrow 
        // function remains the same throughout the lifecycle of the function and is always bound to the value of this 
        // in the closest non - arrow parent function.

        // arrow functions can never be used as constructor functions. Hence, they can never be invoked with the new keyword.

        // Arrow functions can never have duplicate named parameters, whether in strict or non-strict mode.
        (x, x) => { }  // SyntaxError: duplicate argument names not allowed in this context
    }

    //.call(), .apply(), .bind() what is it
    CallApplyBind() {

    }

    //Event bubbling vs Event capturing
    EventBubblingCapturing() {

    }

    //Promise states
    PromiseStates() {

    }

    //Event loop(micro and macro tasks)
    EventLoop() {

    }

    //Docs to read:
    //https://developer.mozilla.org/en-US/docs/Web/JavaScript
    //https://javascript.info/


    //React:
    //React lifecycles for Mounting, Updating, Unmounting
    ReactLifecycles() {

    }

    //forceUpdate method to rerender component
    ForceUpdateMethod() {

    }

    //Attribute 'key' for iterations.Why it's so important to have it
    AttributeKey() {

    }

    //How VirtualDOM works in React
    VirtualDom() {

    }

    //React doc - https://reactjs.org/docs/getting-started.html
    //(all info is included)


    //Web:
    //Cookie structure ? https ://flaviocopes.com/cookies/
    CookieStructure() {

    }

    //Sessionstorage vs localstorage
    SessionLocalStorage() {

    }

    //CORS
    Cors() {

    }

}