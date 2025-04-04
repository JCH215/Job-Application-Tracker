import { useEffect, useState } from 'react';
import { getAllApplications, createApplication, updateApplication } from "./api";
import './App.css';  // Import the CSS file

function App() {
    const [applications, setApplications] = useState([]);
    const [newApplication, setNewApplication] = useState({ companyName: "", position: "" });

    useEffect(() => {
        getAllApplications().then(res => { if (res && res.data) { setApplications(res.data); } })
            .catch(error => { console.error("Error fetching applications", error); })
    }, []);

    const addApplication = () => {
        createApplication({ ...newApplication, status: "Applied", appliedAt: new Date() })
            .then(res => setApplications([...applications, res.data]));
    };

    const updateApplicationStatus = (appid, newStatus) => {

        const updatedApplication = applications.find(x => x.id == appid);

        updateApplication(appid, {
            id: appid,
            status: newStatus,
            companyName: updatedApplication.companyName,
            position: updatedApplication.position,
            appliedAt: updatedApplication.appliedAt
        }).then(response => {
            setApplications(prevApplications =>
                prevApplications.map(app =>
                    app.id === appid ? { ...app, status: newStatus } : app
                )
            );
        })
            .catch(error => {
                console.error('Error updating application status:', error);
            });
    };

    return (
        <div>
            <h1>Job Applications</h1> 

            <div className="main">
            <div className="applications">
                <table className="table">
                    <thead>
                        <tr>
                            <th>Company Name</th>
                            <th>Position</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {applications.map((app) => (
                            <tr key={app.id}>
                                <td>{app.companyName}</td>
                                <td>{app.position}</td>
                                <td>
                                    <select onChange={e => updateApplicationStatus(app.id, e.target.value)} value={app.status}>
                                        <option value="Applied">Applied</option>
                                        <option value="Interview">Interview</option>
                                        <option value="Offer">Offer</option>
                                        <option value="Rejected">Rejected</option>
                                    </select>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            <div className="form">
                <form>
                    <input type="text" required maxLength={200} minLength={1} placeholder="Company Name" onChange={e => setNewApplication({ ...newApplication, companyName: e.target.value })} />
                    <input type="text" required maxLength={100} minLength={1} placeholder="Position" onChange={e => setNewApplication({ ...newApplication, position: e.target.value })} />

                    <button onClick={addApplication} disabled={!newApplication.companyName || !newApplication.position}> Add New Application </button>
                </form>
            </div>
            </div>
        </div>
    );
}

export default App;
