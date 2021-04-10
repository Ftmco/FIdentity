import React, { Component } from 'react';


export class Loader extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <div className="ulLoader" id="loader">
                    <ul className="ulLoaderul" id="ulLoaderul">
                        <li></li>
                        <li></li>
                        <li></li>
                        <li></li>
                        <li></li>
                        <li></li>
                        <li></li>
                        <li></li>
                    </ul>
                </div>
            </div>
        );
    }
}