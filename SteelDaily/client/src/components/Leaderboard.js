import react from "react"
import { Card, CardHeader } from "reactstrap"
export const Leaderboard = ({ leaders }) => {

    return (
        <div>
            <Card>
                <CardHeader>{leaders}</CardHeader>
            </Card>


        </div>




    )

}