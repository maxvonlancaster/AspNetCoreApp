import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Streaming from './components/streaming/Streaming.js';
import Main from './components/main/Main.js';
import AddQuestion from './components/questions/AddQuestion.js'

ReactDOM.render(
    <BrowserRouter>
        <main>
            <Switch>
                <Route exact path="/" component={Main} />
                <Route path="/streaming" component={Streaming} />
                <Route path="/addQuestion" component={AddQuestion} /> 
            </Switch>
        </main>
    </BrowserRouter>,
    document.getElementById('root')
);