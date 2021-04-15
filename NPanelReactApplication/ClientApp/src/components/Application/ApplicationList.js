import React, { Component } from 'react';
import * as icons from 'react-icons/fa';
import { Loader } from './../Lodings/Loader';


export class ApplicationList extends Component {
    static displayName = ApplicationList.displayName;

    constructor(props) {
        super(props);
        this.state = { applications: [], loading: true };
    }

    componentDidMount() {
        this.fetchApplications();
    }

    addNewApplication() {
        alert("New Applciation");
    }

    static renderApplications(applications) {
        return (
            <div>
                <button className="btn btn-primary" onClick={() => { addNewApplication(); }} title="Add New Application"><icons.FaPlus /> Add New Application</button>
                <br />
                <br />
                <table className="table table-custome">
                    <thead>
                        <tr>
                            <th>Icon</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Is Confirm</th>
                            <th>Create Date</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {applications.map(application =>
                            <tr key={application.id}>
                                <td>
                                    <img src={"/images/applications/icon/" + application.icon} />
                                </td>
                                <td>{application.applicationName}</td>
                                <td>{application.applicationEmail}</td>
                                <td>
                                    <p className={application.isConfirm ? "text-success" : "text-danger"}>
                                        <input type="checkbox" checked={application.isConfirm} />
                                    </p>
                                </td>
                                <td>
                                    {application.createDate}
                                </td>
                                <td>
                                    <button className="btn btn-danger btn-sm" title={"Delete " + application.applicationName}><icons.FaTrash /></button>

                                    <button className="btn btn-warning btn-sm" title={"Edit " + application.applicationName}><icons.FaEdit /></button>
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading ?
            <Loader />
            : ApplicationList.renderApplications(this.state.applications);

        return (
            <div>
                <h1 id="tabelLabel" className="text-center" >Applications</h1>
                {contents}
            </div>)
    }


    async fetchApplications() {
        const response = await fetch('/api/Applications/GetApplications');
        const data = await response.json();
        this.setState({ applications: data, loading: false });
    }


}