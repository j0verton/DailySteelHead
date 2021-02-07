import react from "react"
import { Col } from "reactstrap"
import { ActivityFeed } from "../components/ActivityFeed"
import { Leaderboard } from "../components/Leaderboard"

export const LandingPage = () => {

    return (
        <div>
            <Col>
                <ActivityFeed />
            </Col>
            <Col>
                <Leaderboard />
            </Col>
        </div >
    )
}
