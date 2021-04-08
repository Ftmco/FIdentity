import React, { Component } from 'react';

export class ApplicationList extends Component {
    static displayName = ApplicationList.displayName;

    constructor(props) {
        super(props);
        this.state = { applications: [], loading: true };
    }

    componentDidMount() {
        this.fetchApplications();
    }

    static renderApplications(applications) {
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp. (C)</th>
                            <th>Temp. (F)</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {applications.map(application =>
                            <tr key={application.date}>
                                <td>{application.date}</td>
                                <td>{application.temperatureC}</td>
                                <td>{application.temperatureF}</td>
                                <td>{application.summary}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading ?
            <p><em>Loading...</em></p>
            : ApplicationList.renderApplications(this.state.applications);

        return (
            <div>
                <h1 id="tabelLabel" >Applications List</h1>
                <p>this is your applications</p>
                {contents}
            </div>)
    }


    async fetchApplications() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ applications: data, loading: false });
    }
}