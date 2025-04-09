import { useEffect, useState } from 'react';
import { getPagedApplications, createApplication, updateApplication } from "./api";
import './App.css';  // Import the CSS file

const pageSize = 5;

function App() {
    const [applications, setApplications] = useState([]);
    const [pageNo, setPageNo] = useState(1);
    const [totalCount, setTotalCount] = useState(0);

    const [newApplication, setNewApplication] = useState({ companyName: "", position: "" });

    useEffect(() => {
        getPagedApplications(pageSize, pageNo).then(res => {
            if (res && res.data) {
                setApplications(res.data.applications);
                setTotalCount(res.data.totalCount);
            }
        })
            .catch(error => { console.error("Error fetching applications", error); })
    }, [pageNo]);

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
                    <p>Total applications: {totalCount}</p>
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
                            {Array.from({ length: pageSize - applications.length }, () => (
                                <tr>
                                    <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                    <p>Page {pageNo} of {Math.ceil(totalCount / pageSize)}</p>
                    <p className="btns_nav">
                        <button className="btn btn-primary" disabled={pageNo === 1} onClick={() => setPageNo(1)}>First</button>
                        <button className="btn btn-primary" disabled={pageNo === 1} onClick={() => setPageNo(prev => Math.max(prev - 1, 1))}>Prev</button>
                        <button className="btn btn-primary" disabled={pageNo === Math.ceil(totalCount / pageSize)} onClick={() => setPageNo(prev => Math.min(prev + 1, Math.ceil(totalCount / pageSize)))}>Next</button>
                        <button className="btn btn-primary" disabled={pageNo === Math.ceil(totalCount / pageSize)} onClick={() => setPageNo(Math.ceil(totalCount / pageSize))}>Last</button>
                    </p>
                </div>

                <div className="form">
                    <p>Add a New Application</p>
                    <form>
                        <input type="text" required maxLength={200} minLength={1} placeholder="Company Name" onChange={e => setNewApplication({ ...newApplication, companyName: e.target.value })} />
                        <input type="text" required maxLength={100} minLength={1} placeholder="Position" onChange={e => setNewApplication({ ...newApplication, position: e.target.value })} />

                        <button type="button" onClick={addApplication} disabled={!newApplication.companyName || !newApplication.position}> SUBMIT </button>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default App;
